using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State initialState;
    public State currentState;//private
    // Start is called before the first frame update
    void Start()
    {
        currentState=initialState;
    }

    // Update is called once per frame
    void Update()
    {
        State nextState = currentState.Run(gameObject);
        
        if (nextState) 
        {
            currentState = nextState;
        }
    }

    private void OnDrawGizmos()//dibujar area de escucha
    {      
        if (currentState)
        {
            currentState.DrawAllActionsGizmos(gameObject);
        }else if(initialState)
        {
            initialState.DrawAllActionsGizmos(gameObject);
        }
    }

}
