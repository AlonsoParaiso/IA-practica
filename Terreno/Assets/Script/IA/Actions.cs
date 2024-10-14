using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Actions : ScriptableObject
{

    public abstract void DrawGizmos(GameObject owner);

    public abstract bool Check(GameObject owner);//ejecutar comportamiento



}
