using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "SeeAction (A)", menuName = "ScriptableObject/Actions/SeeAction")]//IMPORTANTE
public class SeeAction : Actions
{
    public float angleVison;
    public override bool Check(GameObject owner)
    {
        GameObject target = owner.GetComponent<Target>().target;
        Vector3 dir = target.transform.position - owner.transform.position;

        float angle = Vector3.Angle(dir, owner.transform.forward);

        Debug.DrawRay(owner.transform.position + owner.transform.up, dir);

        if (angle < angleVison * 0.5f)
        {
            RaycastHit hits;


            if (Physics.Raycast(owner.transform.position + owner.transform.up, dir.normalized, out hits, 30f))
            {

                if (hits.collider.gameObject == target)
                {
                    return true; //le vee
                }

            }

        }


        // RaycastHit[] hits = Physics.RaycastAll(owner.transform.position, Vector3.forward, 30f);//https://www.youtube.com/watch?v=ZOotW54NZto
        // GameObject target = owner.GetComponent<Target>().target;

        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {
        
    }
}
