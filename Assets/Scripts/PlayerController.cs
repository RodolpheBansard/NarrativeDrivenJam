using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1;

    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 movement;

    private bool canMove = false;



    void Update()
    {
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
       

    }

    private void FixedUpdate()
    {
        if(movement == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }

        rb.velocity = movement*moveSpeed*Time.fixedDeltaTime;
    }

    public void drawingFinished()
    {
        canMove = true;
    }

    
}
