using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modifier
{
    public ModifierData baseData;
    public int currentStacks;
    public MonoBehaviour target;
    protected float totalDuration;
    protected float startTime;

    public abstract void Instantiate(bool timedStack);
    public abstract void AddStack(bool timed);
    public abstract void Refresh();
    public abstract void Remove();
    protected abstract IEnumerator TimedStackCoroutine();
}

public abstract class Modifier<TModifierDataType> : Modifier
{
    public TModifierDataType specialData;

    public override void Instantiate(bool timedStack)
    {
        AddStack(timedStack);
    }
    public override void AddStack(bool timed)
    {
        currentStacks++;

        if (timed)
            target.StartCoroutine(TimedStackCoroutine());
    }
    public override void Refresh()
    {
        startTime = Time.time;
    }
    public override void Remove()
    {
        ModifiersReceiver rm = target.GetComponent<ModifiersReceiver>();
        Type type = this.GetType();

        rm.Modifiers[type].Remove(this);
        if (rm.Modifiers[type].Count <= 0)
            rm.Modifiers.Remove(type);
    }
    protected override IEnumerator TimedStackCoroutine()
    {
        yield return new WaitForSeconds(totalDuration);
        currentStacks--;
    }
}

public abstract class ModifierData
{
    public string modifierName;
    public bool singleInstanceOnly;
    public int maxStacks;
    public bool refreshOnReapply;
    public bool timedStacks;
}