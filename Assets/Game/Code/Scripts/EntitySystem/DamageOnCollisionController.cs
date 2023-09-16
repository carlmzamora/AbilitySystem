using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionController : MonoBehaviour, ICollisionDamaging
{
    [SerializeField] private float damage;
    public float Damage => damage;

    private void OnCollisionEnter(Collision other)
    {
        IHealthStatCapable healthController = other.gameObject.GetComponent<IHealthStatCapable>();

        healthController?.TakeDamage(damage);

        Destroy(gameObject);
    }
}
