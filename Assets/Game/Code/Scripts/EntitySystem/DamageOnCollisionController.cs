using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionController : MonoBehaviour, IDamaging, IModifierCapable
{
    [SerializeField] private float damage;
    public float Damage => damage;

    [SerializeField] private List<ModifierFactory> modifiers;
    public List<ModifierFactory> Modifiers => modifiers;

    private void OnCollisionEnter(Collision other)
    {
        IHealthStatCapable healthController = other.gameObject.GetComponent<IHealthStatCapable>();

        healthController?.TakeDamage(damage);

        ApplyModifiers(other.gameObject);

        Destroy(gameObject);
    }

    private void ApplyModifiers(GameObject other)
    {
        ModifiersReceiver rmc = other.GetComponent<ModifiersReceiver>();

        if (rmc == null) return;

        for(int i = 0; i < modifiers.Count; i++)
        {
            rmc.ApplyModifier(modifiers[i].GetModifier(rmc.GetComponent<MonoBehaviour>()));
        }
    }
}
