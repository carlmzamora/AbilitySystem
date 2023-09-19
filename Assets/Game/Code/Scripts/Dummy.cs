using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour, IMoveSpeedStatCapable
{
    [SerializeField] protected float baseMoveSpeed;
    public float BaseMoveSpeed => baseMoveSpeed;

    protected float currentMoveSpeed;
    public float CurrentMoveSpeed => currentMoveSpeed;

    public void SetCurrentMoveSpeed(float value)
    {
        currentMoveSpeed = value;
    }
}
