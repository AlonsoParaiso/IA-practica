using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "SeeAction (A)", menuName = "ScriptableObject/Actions/SeeAction")]//IMPORTANTE
public class SeeAction : Actions
{
    public float angleVison; //el angulo que le das a la vista (mas o menos la vista es de 100)
    public override bool Check(GameObject owner)
    {
        GameObject target = owner.GetComponent<Target>().target;
        Vector3 dir = target.transform.position - owner.transform.position;//la direccion donde ve la vista

        float angle = Vector3.Angle(dir, owner.transform.forward);//coge el angulo del player y donde esta el enemigo

        Debug.DrawRay(owner.transform.position + owner.transform.up, dir);

        if (angle < angleVison * 0.5f)//si el angulo que esta viendo es menor a su angulo de vision
        {
            RaycastHit hits;//el raycast se utiliza si le da


            if (Physics.Raycast(owner.transform.position + owner.transform.up, dir.normalized, out hits, 30f))//te mira si estas dando el raycast
            {

                if (hits.collider.gameObject == target)//si das al taget 
                {
                    return true; //le ve
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
