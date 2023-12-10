using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Shoot Ability")]
public class ShootAbilityFactory : AbilityFactory<ShootAbilityData, ShootAbility> { }

public class ShootAbility : Ability<ShootAbilityData>
{
    private List<Modifier> spawnModifierInstances = new();
    private IShooting shootingController;

    private int currentSpawnCount;
    private float currentConeAngle;

    public override void Setup(GameObject owner)
    {
        shootingController = owner.GetComponent<IShooting>();

        currentSpawnCount = specialData.spawnCount;
        currentConeAngle = specialData.coneAngle;

        CreateModifierInstancesFromData();
    }

    public override void Activate(GameObject owner)
    {
        if (shootingController != null)
        {
            if(currentSpawnCount == 0)
            {
                Debug.LogError("Shoot ability is spawning nothing!");
            }
            else if(currentSpawnCount == 1)
            {
                GameObject spawn = Object.Instantiate(specialData.spawnReference, shootingController.ProjectileSpawnpoint.position, shootingController.ProjectileSpawnpoint.rotation);
                ApplySpawnModifiers(spawn);
            }
            else if(currentSpawnCount > 1)
            {
                int steps = currentSpawnCount - 1;
                float stepValue = currentConeAngle / steps;

                for (int i = 0; i <= steps; i++)
                {
                    GameObject spawn = Object.Instantiate(specialData.spawnReference, shootingController.ProjectileSpawnpoint.position, shootingController.ProjectileSpawnpoint.rotation);
                    spawn.transform.Rotate(new Vector3(0, (-currentConeAngle * 0.5f) + (i * stepValue), 0));
                    ApplySpawnModifiers(spawn);
                }
            }                               
        }
    }

    public override void UpdateAttributes()
    {
        //UPDATE MODIFIERS HERE WHEN CALLED BY LISTENER or smthng
        throw new System.NotImplementedException();
    }

    private void CreateModifierInstancesFromData()
    {
        foreach (ModifierFactory spawnModifierFactory in specialData.spawnModifiers)
        {
            spawnModifierInstances.Add(spawnModifierFactory.GetModifier());
        }
    }

    private void ApplySpawnModifiers(GameObject spawn)
    {
        IModifierSender modifierSender = spawn.GetComponent<IModifierSender>();
        if (modifierSender != null)
        {
            foreach (Modifier spawnModifierInstance in spawnModifierInstances)
            {
                Modifier modifierToSend = spawnModifierInstance.Clone();

                modifierSender.Modifiers.Add(modifierToSend);
            }
        }
    }
}

[System.Serializable]
public class ShootAbilityData : AbilityData
{
    public GameObject spawnReference;
    public List<ModifierFactory> spawnModifiers;
    public Attribute_Int spawnCount;
    public Attribute_Float coneAngle;
}