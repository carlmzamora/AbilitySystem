using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModifierFactory : ScriptableObject
{
    public abstract Modifier GetModifier();
    public abstract Modifier GetModifier(MonoBehaviour target);
}

public class ModifierFactory<TModifierDataType, TModifierType> : ModifierFactory
    where TModifierType : Modifier<TModifierDataType>, new()
    where TModifierDataType : ModifierData
{
    public TModifierDataType data;

    public override Modifier GetModifier()
    {
        return new TModifierType { baseData = this.data, specialData = this.data };
    }

    public override Modifier GetModifier(MonoBehaviour target)
    {
        return new TModifierType { baseData = this.data, specialData = this.data, target = target };
    }
}