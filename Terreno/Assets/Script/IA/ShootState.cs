using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootState (S)", menuName = "ScriptableObject/States/ShootState")]//IMPORTANTE
public class ShootState : State
{
    public GameObject shoot;
    public float timeShoot, rotationSpeed;

    private float currentTime;
    public override State Run(GameObject owner)
    {
        currentTime +=Time.deltaTime;
        State nextState = CheckActions(owner);
        GameObject target = owner.GetComponent<Target>().target;
        Quaternion roation = Quaternion.LookRotation(target.transform.position - owner.transform.position);
        owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, roation, Time.deltaTime * rotationSpeed);
        if(currentTime > timeShoot) 
        {
            GameObject bullet = Instantiate(shoot, new Vector3(owner.transform.position.x, owner.transform.position.y, owner.transform.position.z),Quaternion.identity);
            bullet.GetComponent<Shoot>().dir = owner.transform.forward;
            
            currentTime = 0;
        }

        return nextState;
    }
}
