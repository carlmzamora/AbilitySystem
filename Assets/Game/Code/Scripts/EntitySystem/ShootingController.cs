using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour, IShooting
{
    [SerializeField] private Transform projectileSpawnPoint;
    public Transform ProjectileSpawnpoint => projectileSpawnPoint;
}
