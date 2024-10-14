using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

[CreateAssetMenu(fileName = "HearAction (A)", menuName = "ScriptableObject/Actions/HearAction")]//IMPORTANTE
public class HearAction : Actions
{
    public float radius = 50f;
    public override bool Check(GameObject owner)
    {
        RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position, radius, Vector3.up);
        GameObject target = owner.GetComponent<Target>().target;

        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.gameObject == target) 
            {
                return true; //le escuchamos / olemos
            }
        }
        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(owner.transform.position, radius);
    }
}
