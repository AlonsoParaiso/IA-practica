using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "PatrolState (S)", menuName = "ScriptableObject/States/PatrolState")]//IMPORTANTE
public class PatrolState : State
{
 

    public Vector3 [] guardsPoints;

    public float currentTime,maxTime;
    private int i=0;
    public string blendParametrer;

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);
        NavMeshAgent agent = owner.GetComponent<NavMeshAgent>();
        Animator anim = owner.GetComponent<Animator>();

        if (Mathf.Approximately(agent.remainingDistance,agent.stoppingDistance)) 
        { 
            currentTime += Time.deltaTime;
        }

        agent.SetDestination(guardsPoints[i]);

        if (currentTime >= maxTime) 
        {
            i++;
            if (i >= guardsPoints.Length)
            {
                i = 0;
            }
            currentTime = 0;
            
        }

        anim.SetFloat(blendParametrer, agent.velocity.magnitude / agent.speed);

        return nextState;
    }
}
