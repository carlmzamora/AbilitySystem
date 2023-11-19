using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AbilityModifier/Float")]
public class AbilityModifier_Float : ScriptableObject
{
    public AbilityAttribute attributeName;
    public AbilityAttributeOperation operationToApply;
    public float value;
}

public enum AbilityAttributeOperation
{
    ADD,
    MULTIPLY,
    SET
}