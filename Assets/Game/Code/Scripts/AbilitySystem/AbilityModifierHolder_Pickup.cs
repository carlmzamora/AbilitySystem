using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityModifierHolder_Pickup : MonoBehaviour
{
    [SerializeField] private EventNotifier_AbilityModifierContent OnPickUpEvent;
    [SerializeField] private List<FloatAbilityAttributeModifier> floatAttributes;
    [SerializeField] private List<IntAbilityAttributeModifier> intAttributes;

    private AbilityModifierContent contents;

    private void Start()
    {
        contents.floatAbilityAttributeModifiers = floatAttributes;
        contents.intAbilityAttributeModifiers = intAttributes;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnPickUpEvent.Raise(contents);
    }
}