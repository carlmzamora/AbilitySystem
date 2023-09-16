using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour, IHealthStatCapable
{
    [SerializeField] private float currentHealth;
    public float CurrentHealth => currentHealth;

    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
    }

    public void SetHealth(float amount)
    {
        currentHealth = amount;
    }

    public void AddMaxHealth(float amount)
    {
        maxHealth += amount;
    }

    public void SetMaxHealth(float amount)
    {
        maxHealth = amount;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
