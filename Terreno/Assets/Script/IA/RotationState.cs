using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "RotationState (S)", menuName = "ScriptableObject/States/RotationState")]//IMPORTANTE
public class RotationState : State
{
    public float speedRotation = 1f;
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        owner.transform.Rotate(0, speedRotation * Time.deltaTime, 0);

        return nextState;
    }
}
