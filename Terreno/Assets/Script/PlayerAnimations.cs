using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement_rb rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<PlayerMovement_rb>();
    }

    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxisRaw("Horizontal"); //GetAxisRaw sirve para teclado y mando
        //float z = Input.GetAxisRaw("Vertical");
        //bool shifht = Input.GetKey(KeyCode.LeftShift);

        //if (x!=0||z!=0) 
        //{
        //    if (shifht)
        //    {
        //        animator.SetBool("isRunning",true);
        //        animator.SetBool("isWalking", false);
        //    }
        //    else
        //    {
        //        animator.SetBool("isRunning", false);
        //        animator.SetBool("isWalking", true);
        //    }
        //}
        //else
        //{
        //    animator.SetBool("isRunning", false);
        //    animator.SetBool("isWalking", false);
        //}
    }
    private void LateUpdate()
    {
        animator.SetFloat("Speed", rb.GetCurrentSpeed()/rb.running);
    }
}
