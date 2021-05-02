﻿using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> spawnpointsLvl1;
    public CinemachineVirtualCamera camera;
    private int currentCheckpointIndex = 0;

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

    public void Detected()
    {
        animator.SetTrigger("death");        
        StartCoroutine(WaitDeath()); 

    }

    public void UpdateCheckpoint()
    {
        currentCheckpointIndex++;
    }

    IEnumerator WaitDeath()
    {
        canMove = false;
        movement = Vector2.zero;
        camera.m_Lens.FieldOfView = 50;
        yield return new WaitForSeconds(0.92f);
        transform.position = spawnpointsLvl1[currentCheckpointIndex].transform.position;
        camera.m_Lens.FieldOfView = 70;
        yield return new WaitForSeconds(1.83f);

        canMove = true;
    }
}