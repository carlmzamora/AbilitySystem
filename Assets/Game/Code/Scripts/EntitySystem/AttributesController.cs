using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesController : MonoBehaviour
{
    [SerializeField] private float defaultMoveSpeed = 3000;

    private float currentMoveSpeed;
    private float baseMoveSpeed;
    private float percentBasedMoveSpeedMultipliers;
    private float flatMoveSpeedBonuses;

    void Start()
    {
        baseMoveSpeed = defaultMoveSpeed;
        currentMoveSpeed = baseMoveSpeed;
    }

    #region MOVESPEED

    public void AddPercentBasedMoveSpeedMultiplier(float value)
    {
        percentBasedMoveSpeedMultipliers += value;
        UpdateCurrentMoveSpeed();
    }

    public void RemovePercentBasedMoveSpeedMultiplier(float value)
    {
        percentBasedMoveSpeedMultipliers -= value;
        UpdateCurrentMoveSpeed();
    }

    public void AddFlatMoveSpeedBonus(float value)
    {
        flatMoveSpeedBonuses += value;
        UpdateCurrentMoveSpeed();
    }

    public void RemoveFlatMoveSpeedBonus(float value)
    {
        flatMoveSpeedBonuses -= value;
        UpdateCurrentMoveSpeed();
    }

    private void UpdateCurrentMoveSpeed()
    {
        currentMoveSpeed = (baseMoveSpeed + flatMoveSpeedBonuses) * (percentBasedMoveSpeedMultipliers * 0.01f);
    }

    #endregion
}
