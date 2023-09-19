using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveSpeedStatCapable
{
    float BaseMoveSpeed { get; }
    float CurrentMoveSpeed { get; }

    void SetCurrentMoveSpeed(float value);
}
