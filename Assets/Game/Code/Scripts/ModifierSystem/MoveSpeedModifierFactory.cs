using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modifiers/Move Speed Modifier")]
public class MoveSpeedModifierFactory : ModifierFactory<MoveSpeedModifierData, MoveSpeedModifier> { }

public class MoveSpeedModifier : Modifier<MoveSpeedModifierData>
{
    private AttributesController ac;

    public override void Instantiate(bool timedStack)
    {
        ac = target.gameObject.GetComponent<AttributesController>();

        if (ac == null)
        {
            Debug.LogError("Attempting to modify movespeed, but there's so AttributesController!");
            return;
        }

        base.Instantiate(timedStack);
        totalDuration = specialData.duration;
        target.StartCoroutine(DurationCoroutine());
    }

    public override Modifier Clone()
    {
        return new MoveSpeedModifier { baseData = this.baseData, specialData = this.specialData, target = this.target };
    }

    public override void AddStack(bool timed)
    {
        base.AddStack(timed);

        if (specialData.usePercent)
            ac.AddPercentBasedMoveSpeedMultiplier(specialData.value);
        else
            ac.AddFlatMoveSpeedBonus(specialData.value);
    }

    protected override IEnumerator TimedStackCoroutine()
    {
        yield return base.TimedStackCoroutine();

        if (specialData.usePercent)
            ac.RemovePercentBasedMoveSpeedMultiplier(specialData.value);
        else
            ac.RemoveFlatMoveSpeedBonus(specialData.value);
    }

    private IEnumerator DurationCoroutine()
    {
        startTime = Time.time;
        while(Time.time - startTime <= totalDuration)
        {
            yield return new WaitForEndOfFrame();
        }

        if (specialData.usePercent)
            ac.RemovePercentBasedMoveSpeedMultiplier(specialData.value * currentStacks);
        else
            ac.RemoveFlatMoveSpeedBonus(specialData.value * currentStacks);

        Remove();
    }
}

[System.Serializable]
public class MoveSpeedModifierData : ModifierData
{
    public bool usePercent;
    public float value;
    public float duration;
}
