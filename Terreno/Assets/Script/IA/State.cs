using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

[System.Serializable]
public struct ActionParameters
{
    [Tooltip("Action that is ganna be executes")]
    public Actions action;
    [Tooltip("indicates if the actions check must be true or false")]
    public bool actionValue;
}











[System.Serializable]
public struct StateParamatres
{
    [Tooltip("ActionsParametres, Array")]
    public ActionParameters[] actionParameters;
    [Tooltip("if the actions check equals actionValue, nextState is pushed")]
    public State nextState;
    [Tooltip("Se cumplen todas las condiciones o solo se tiene que cumplir una?")]
    public bool and;
}



public abstract class State : ScriptableObject
{
    public StateParamatres[] stateParamatres;


    //comprueba si las acciones se cumplen y ademas ejecuta el comportamiento AOCIADO AL ESTADO
    public abstract State Run(GameObject owner);

    public void DrawAllActionsGizmos(GameObject owner)
    {
        foreach( StateParamatres paramatres in stateParamatres)
        {
            foreach(ActionParameters aP in paramatres.actionParameters)
            {
                aP.action.DrawGizmos(owner);
            }
        }
    }
    

    protected State CheckActions(GameObject owner)
    {
       
        for (int i = 0; i < stateParamatres.Length; ++i)
        {
            bool morir =true;
           
            for(int j = 0; j < stateParamatres[i].actionParameters.Length; ++j)
            {
                ActionParameters actionParameters = stateParamatres[i].actionParameters[j];
                if (actionParameters.action.Check(owner) == actionParameters.actionValue)
                {
                    if (!stateParamatres[i].and)//si se cumple una
                    {
                        return stateParamatres[i].nextState;// le devolvemos el siguiente estado
                    }
                }
                else if (stateParamatres[i].and)
                {
                    morir = false;
                    //estamos seguros de que esta acion no se ha cumplido
                    //y el disenyador me he marcado que se tienen que cumplir todas
                    break;//salimos del bucle, porque una accion no se ha cumplido y estamos en and
                }
            }
            //si llegamos hasta aqui, lo que significa que el disenyador ha marcado todas las acciones tienen que cumplirse y hay que comprobar si se han cumplido todas
            if (stateParamatres[i].and && morir)
            {
                return stateParamatres[i].nextState;
            }
        }
        return null;//ninguna accion se cumple

    }



}
