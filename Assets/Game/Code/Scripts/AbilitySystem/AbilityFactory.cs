using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityFactory : ScriptableObject
{
    public abstract Ability GetAbility();
}

public class AbilityFactory<TAbilityDataType, TAbilityType> : AbilityFactory
    where TAbilityType : Ability<TAbilityDataType>, new()
    where TAbilityDataType : AbilityData
{
    public TAbilityDataType data;

    public override Ability GetAbility()
    {
        return new TAbilityType { data = this.data, specialData = this.data };
    }
}
