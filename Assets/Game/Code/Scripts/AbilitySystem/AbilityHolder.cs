using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    enum AbilityState
    {
        READY,
        ACTIVE,
        COOLDOWN
    }

    [SerializeField] private Ability ability;
    [SerializeField] private bool useMouseButton = false;
    [SerializeField] private KeyCode keyToPress;
    [SerializeField] private int mouseButtonInt;

    private float activeTimeProgress;
    private float cooldownTimeProgress;
    private AbilityState state = AbilityState.READY;

    private void Start()
    {
        ability.Setup(gameObject);
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
                        ability.Activate(gameObject);
                        state = AbilityState.ACTIVE;
                        activeTimeProgress = ability.duration;
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(mouseButtonInt))
                    {
                        ability.Activate(gameObject);
                        state = AbilityState.ACTIVE;
                        activeTimeProgress = ability.duration;
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
                    cooldownTimeProgress = ability.cooldown;
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
