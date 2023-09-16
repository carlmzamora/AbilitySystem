using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public string abilityName;
    public float duration;
    public float cooldown;

    public virtual void Setup(GameObject owner) { }
    public virtual void Activate(GameObject owner) { }
}
