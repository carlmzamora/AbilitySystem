using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModifierCapable
{
    List<ModifierFactory> Modifiers { get; }
}
