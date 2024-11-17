using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<PlayerMovement_rb>())
        {
           
         
                LoseLife playerHealth = collider.gameObject.GetComponent<LoseLife>();
                if (playerHealth)
                {
                    playerHealth.LoseLifes();
                    //Destroy(collision.gameObject);
                }

           
        }
}

}