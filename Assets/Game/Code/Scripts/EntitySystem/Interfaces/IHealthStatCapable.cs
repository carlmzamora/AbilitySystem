using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthStatCapable : IDamageable
{
    float CurrentHealth { get; }
    float MaxHealth { get; }
    void AddHealth(float amount);
    void SetHealth(float amount);
    void AddMaxHealth(float amount);
    void SetMaxHealth(float amount);
}
