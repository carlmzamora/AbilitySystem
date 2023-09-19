using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModifierSender
{
    List<ModifierFactory> Modifiers { get; }
}
