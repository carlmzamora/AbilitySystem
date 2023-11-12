using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Shoot Ability")]
public class ShootAbilityFactory : AbilityFactory<ShootAbilityData, ShootAbility> { }

public class ShootAbility : Ability<ShootAbilityData>
{
    private List<Modifier> objectModifierInstances = new();
    private IShooting shootingController;

    public override void Setup(GameObject owner)
    {
        shootingController = owner.GetComponent<IShooting>();

        CreateModifierInstancesFromData();
    }

    public override void Activate(GameObject owner)
    {
        if (shootingController != null)
        {
            GameObject spawn = Object.Instantiate(specialData.objectReference, shootingController.ProjectileSpawnpoint.position, shootingController.ProjectileSpawnpoint.rotation);

            IModifierSender modifierSender = spawn.GetComponent<IModifierSender>();
            if(modifierSender != null)
            {
                foreach(Modifier objectModifierInstance in objectModifierInstances)
                {
                    Modifier modifierToSend = objectModifierInstance.Clone();

                    modifierSender.Modifiers.Add(modifierToSend);
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
        foreach (ModifierFactory objectModifierFactory in specialData.objectModifiers)
        {
            objectModifierInstances.Add(objectModifierFactory.GetModifier());
        }
    }
}

[System.Serializable]
public class ShootAbilityData : AbilityData
{
    public GameObject objectReference;
    public List<ModifierFactory> objectModifiers;
    public int objectCount;
    public float coneAngle;
}