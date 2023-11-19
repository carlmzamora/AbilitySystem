using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AbilityAttributeModifier/Float")]
public class FloatAbilityAttributeModifier : ScriptableObject
{
    public AbilityAttribute attributeName;
    public AbilityAttributeOperation operationToApply;
    public float value;
}

[CreateAssetMenu(menuName = "AbilityAttributeModifier/Int")]
public class IntAbilityAttributeModifier : ScriptableObject
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