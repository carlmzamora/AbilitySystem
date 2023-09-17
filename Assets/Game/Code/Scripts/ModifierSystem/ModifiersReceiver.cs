using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiersReceiver : MonoBehaviour
{
    [SerializeField] private Dictionary<Type, List<Modifier>> modifiers = new();
    public Dictionary<Type, List<Modifier>> Modifiers => modifiers;

    public void ApplyModifier(Modifier modifier)
    {
        ModifierData baseData = modifier.baseData;
        Type modifierType = modifier.GetType();

        List<Modifier> currentModifierList = CheckModifierKeyExists(modifierType);        
        int instanceCount = currentModifierList.Count;

        if (instanceCount <= 0) //create first instance
        {
            modifier.Instantiate(baseData.timedStacks);
            currentModifierList.Add(modifier);
            Debug.Log("Ola!");
        }
        else
        {
            if(baseData.singleInstanceOnly)
            {
                Modifier firstInstance = currentModifierList[0];
                int firstInstanceStacks = firstInstance.currentStacks;

                if(baseData.maxStacks == 0)
                {
                    firstInstance.AddStack(baseData.timedStacks);

                    if (baseData.refreshOnReapply)
                        firstInstance.Refresh();
                }
                else if(baseData.maxStacks == 1)
                {
                    if (baseData.refreshOnReapply)
                        firstInstance.Refresh();
                }
                else if(baseData.maxStacks > 1)
                {
                    if(firstInstanceStacks < baseData.maxStacks)
                    {
                        firstInstance.AddStack(baseData.timedStacks);
                    }

                    if (baseData.refreshOnReapply)
                        firstInstance.Refresh();
                }
                else
                {
                    Debug.LogError("Attempting to create modifier with invalid max stacks!");
                }
            }
            else
            {

            }                
        }
    }

    private List<Modifier> CheckModifierKeyExists(Type type)
    {
        if (!modifiers.ContainsKey(type))
        {
            List<Modifier> newModifierList = new();
            modifiers.Add(type, newModifierList);
            return newModifierList;
        }
        else
            return modifiers[type];
    }
}