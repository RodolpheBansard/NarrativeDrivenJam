using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehaviour : MonoBehaviour
{
    public bool isPatrolling = true;

    public Animator animator;
    public List<Transform> waypoints;
    public List<string> directions;
    public float moveSpeed = 3;
    public AudioClip caughtRobotSound;

    private int currentIndex = 0;



    void Start()
    {
        transform.position = waypoints[currentIndex].position;
        currentIndex++;
        TriggerAnimation();
    }


    void Update()
    {        
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndex].position, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[currentIndex].position)
        {            
            currentIndex++;
            if (currentIndex == waypoints.Count)
            {
                currentIndex = 0;
            }
            
        }
        TriggerAnimation();
    }

    private void TriggerAnimation()
    {
        if (transform.position.x < waypoints[currentIndex].position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(directions[currentIndex] == "down")
        {
            transform.localScale = new Vector3(transform.localScale.x*-1, 1, 1);
        }
        
        animator.SetTrigger(directions[currentIndex]);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.parent.gameObject.GetComponent<PlayerController>() != null || collision.gameObject.GetComponent<PlayerController>())
        {
            FindObjectOfType<AudioSource>().PlayOneShot(caughtRobotSound, .7f);
            FindObjectOfType<PlayerController>().Detected();
        }
        
    }
}
