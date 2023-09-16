using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float defaultTravelSpeed = 500;
    [SerializeField] private float lifetime = 2;

    protected virtual void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * defaultTravelSpeed);
        Invoke("Remove", lifetime);
    }

    protected virtual void Remove()
    {
        Destroy(this.gameObject);
    }
}
