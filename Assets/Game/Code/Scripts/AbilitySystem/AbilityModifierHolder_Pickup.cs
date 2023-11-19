using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityModifierHolder_Pickup : MonoBehaviour
{
    [SerializeField] private EventNotifierAbilityModifier_Float OnPickUpEvent;
    [SerializeField] private List<AbilityModifier_Float> floatAttributes;

    private void OnTriggerEnter(Collider other)
    {
        foreach(AbilityModifier_Float modifier in floatAttributes)
        {
            OnPickUpEvent.Raise(modifier);
        }
    }
}