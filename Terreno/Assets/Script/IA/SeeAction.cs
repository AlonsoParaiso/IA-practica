using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeeAction (A)", menuName = "ScriptableObject/Actions/SeeAction")]//IMPORTANTE
public class SeeAction : Actions
{
    public override bool Check(GameObject owner)
    {
        RaycastHit[] hits = Physics.RaycastAll(owner.transform.position, Vector3.forward, 30f);//https://www.youtube.com/watch?v=ZOotW54NZto
        GameObject target = owner.GetComponent<Target>().target;

        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {
        throw new System.NotImplementedException();
    }
}
