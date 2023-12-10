using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    public AbilityData data;

    public abstract void Setup(GameObject owner);
    public abstract void Activate(GameObject owner);
    public abstract void UpdateAttributes();
}

public abstract class Ability<TAbilityDataType> : Ability
{
    public TAbilityDataType specialData;
}

public class AbilityData
{
    public string abilityName;
    public Attribute_Float duration;
    public Attribute_Float cooldown;
}
