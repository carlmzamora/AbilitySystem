using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        transform.position = target.position + offset;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}