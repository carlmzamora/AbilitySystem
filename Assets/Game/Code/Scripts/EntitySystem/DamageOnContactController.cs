using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContactController : MonoBehaviour, IDamaging, IModifierSender
{
    [SerializeField] private float damage;
    public float Damage => damage;

    private List<Modifier> modifiers = new();
    public List<Modifier> Modifiers => modifiers;

    private void OnTriggerEnter(Collider other)
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
            modifiers[i].SetTarget(rmc.GetComponent<MonoBehaviour>());
            rmc.ApplyModifier(modifiers[i]);
        }
    }
}
