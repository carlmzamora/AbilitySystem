using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformVariableUpdater : MonoBehaviour
{
    public TransformVariable toUpdate;

    void Start()
    {
        toUpdate.value = transform;
    }

    void Update()
    {
        toUpdate.value = transform;
    }
}
