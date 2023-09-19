using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesController : MonoBehaviour
{
    private IMoveSpeedStatCapable moveSpeedStatUser;

    private float baseMoveSpeed;
    private float percentBasedMoveSpeedMultipliers;
    private float flatMoveSpeedBonuses;

    void Start()
    {
        moveSpeedStatUser = GetComponent<IMoveSpeedStatCapable>();

        baseMoveSpeed = moveSpeedStatUser.BaseMoveSpeed;
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
        float currentMoveSpeed = (baseMoveSpeed + flatMoveSpeedBonuses) * (1 + percentBasedMoveSpeedMultipliers * 0.01f);
        moveSpeedStatUser.SetCurrentMoveSpeed(currentMoveSpeed);
    }

    #endregion
}
