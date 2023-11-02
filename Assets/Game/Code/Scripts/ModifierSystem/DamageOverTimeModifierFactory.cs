using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Modifiers/Damage Over Time")]
public class DamageOverTimeModifierFactory : ModifierFactory<DamageOverTimeModifierData, DamageOverTimeModifier> { }

public class DamageOverTimeModifier : Modifier<DamageOverTimeModifierData>
{
    private HealthController healthController;
    private float lastTickTime;
    private float timeBetweenRefreshAndLastTick;

    public override void Instantiate(bool timedStack)
    {
        base.Instantiate(timedStack);

        totalDuration = specialData.tickCount * specialData.tickInterval;
        healthController = target.GetComponent<HealthController>();
        target.StartCoroutine(DamageOverTimeCoroutine());
    }

    private IEnumerator DamageOverTimeCoroutine()
    {
        startTime = Time.time;
        while (Time.time - startTime <= totalDuration)
        {
            yield return new WaitForSeconds(specialData.tickInterval);
            healthController.TakeDamage(specialData.damagePerTick * currentStacks);
            lastTickTime = Time.time;
        }

        Remove();
    }
    public override void Refresh()
    {
        float timeOfRefresh = Time.time;

        if (lastTickTime > 0)
        {
            timeBetweenRefreshAndLastTick = lastTickTime - timeOfRefresh;
        }
        else
        {
            timeBetweenRefreshAndLastTick = startTime - timeOfRefresh;
        }

        startTime = Time.time + timeBetweenRefreshAndLastTick; //adjust resetting of time to ensure no extra tick occurs
    }
}

[System.Serializable]
public class DamageOverTimeModifierData : ModifierData
{
    public float damagePerTick;
    public int tickCount;
    public float tickInterval;
}
