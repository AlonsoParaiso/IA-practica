using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName ="ChaseState (S)",menuName ="ScriptableObject/States/ChaseState")]//IMPORTANTE

public class ChaseState : State
{
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent agent = owner.GetComponent<NavMeshAgent>();
        GameObject target= owner.GetComponent<Target>().target;

        agent.SetDestination(target.transform.position);
        

        return nextState;
    }
}
