using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Shoot Projectile")]
public class ShootProjectileAbility : Ability
{
    [SerializeField] private GameObject projectileReference;
    private IShooting shootingController;

    public override void Setup(GameObject owner)
    {
        shootingController = owner.GetComponent<IShooting>();
    }

    public override void Activate(GameObject owner)
    {
        /*if (shootingController != null)
            Instantiate(projectileReference, shootingController.ProjectileSpawnpoint.position, shootingController.ProjectileSpawnpoint.rotation);*/
    }

    public override void UpdateAttributes()
    {
        throw new System.NotImplementedException();
    }
}
