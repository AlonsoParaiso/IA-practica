using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "GuardState (S)", menuName = "ScriptableObject/States/GuardState")]//IMPORTANTE
public class GuardState : State
{
    public Vector3 guardPoint;
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent agent = owner.GetComponent<NavMeshAgent>();
        agent.SetDestination(guardPoint);

        return nextState;
    }
}
