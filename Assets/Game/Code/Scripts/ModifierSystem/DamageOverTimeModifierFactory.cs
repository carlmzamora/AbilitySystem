using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Modifiers/Damage Over Time")]
public class DamageOverTimeModifierFactory : ModifierFactory<DamageOverTimeModifierData, DamageOverTimeModifier> { }

public class DamageOverTimeModifier : Modifier<DamageOverTimeModifierData>
{
    private HealthController healthController;

    public override void Instantiate(bool timedStack)
    {
        base.Instantiate(timedStack);

        baseData.totalDuration = derivedData.tickCount * derivedData.tickInterval;
        healthController = target.GetComponent<HealthController>();
        target.StartCoroutine(DamageOverTimeCoroutine());
    }

    private IEnumerator DamageOverTimeCoroutine()
    {
        startTime = Time.time;
        while (Time.time - startTime <= baseData.totalDuration)
        {
            yield return new WaitForSeconds(derivedData.tickInterval);
            healthController.TakeDamage(derivedData.damagePerTick * currentStacks);
        }

        Remove();
    }
}

[System.Serializable]
public class DamageOverTimeModifierData : ModifierData
{
    public float damagePerTick;
    public int tickCount;
    public float tickInterval;
}
