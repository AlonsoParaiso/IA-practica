using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

[System.Serializable]
public struct StateParamatres
{
    [Tooltip("indicates if the actions check must be true or false")]
    public bool actionValue;
    [Tooltip("Action that is ganna be executes")]
    public Actions action;
    [Tooltip("if the actions check equals actionValue, nextState is pushed")]
    public State nextState;
}



public abstract class State : ScriptableObject
{
    public StateParamatres[] stateParamatres;


    //comprueba si las acciones se cumplen y ademas ejecuta el comportamiento AOCIADO AL ESTADO
    public abstract State Run(GameObject owner);

    public void DrawAllActionsGizmos(GameObject owner)
    {
        for(int i = 0; i < stateParamatres.Length; i++)
        {
            stateParamatres[i].action.DrawGizmos(owner);
        }
    }
    

    protected State CheckActions(GameObject owner)
    {
       
        for (int i = 0; i < stateParamatres.Length; ++i)
        {
           
            if (stateParamatres[i].actionValue == stateParamatres[i].action.Check(owner))
            {
                return stateParamatres[i].nextState;
            }
        }
        return null;

    }



}
