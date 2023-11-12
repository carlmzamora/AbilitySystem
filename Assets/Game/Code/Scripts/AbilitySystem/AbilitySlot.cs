using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlot : MonoBehaviour
{
    enum AbilityState
    {
        READY,
        ACTIVE,
        COOLDOWN
    }

    [SerializeField] private AbilityFactory ability;
    [SerializeField] private bool useMouseButton = false;
    [SerializeField] private KeyCode keyToPress;
    [SerializeField] private int mouseButtonInt;

    private Ability abilityInstance;

    private float activeTimeProgress;
    private float cooldownTimeProgress;
    private AbilityState state = AbilityState.READY;

    private void Start()
    {
        abilityInstance = ability.GetAbility();
        abilityInstance.Setup(gameObject);
    }

    private void Update()
    {
        switch(state)
        {
            case AbilityState.READY:
                if (!useMouseButton)
                {
                    if (Input.GetKeyDown(keyToPress))
                    {
                        abilityInstance.Activate(gameObject);
                        state = AbilityState.ACTIVE;
                        activeTimeProgress = abilityInstance.data.duration;
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(mouseButtonInt))
                    {
                        abilityInstance.Activate(gameObject);
                        state = AbilityState.ACTIVE;
                        activeTimeProgress = abilityInstance.data.duration;
                    }
                }
                break;
            case AbilityState.ACTIVE:
                if(activeTimeProgress > 0)
                {
                    activeTimeProgress -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.COOLDOWN;
                    cooldownTimeProgress = abilityInstance.data.cooldown;
                }
                break;
            case AbilityState.COOLDOWN:
                if(cooldownTimeProgress > 0)
                {
                    cooldownTimeProgress -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.READY;
                }
                break;
        }
    }
}
