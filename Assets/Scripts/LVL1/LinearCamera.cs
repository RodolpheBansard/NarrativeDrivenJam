using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearCamera : MonoBehaviour
{
    public List<Transform> waypoints;
    public float moveSpeed = 3;
    public float delay = 0;

    private int currentIndex = 0;
    private bool launch = false;

    private int compteur = 0;


    void Start()
    {
        StartCoroutine(WaitBeforeLaunch(delay));
        transform.position = waypoints[currentIndex].position;
        currentIndex++;
    }


    void Update()
    {
        if (launch)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndex].position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[currentIndex].position)
            {
                compteur++;
                if(compteur ==  waypoints.Count && gameObject.tag == "runner")
                {
                    gameObject.GetComponent<LinearCamera>().enabled = false;
                }
                currentIndex++;
                if (currentIndex == waypoints.Count)
                {
                    if(gameObject.tag == "GroupRunner")
                    {
                        gameObject.GetComponent<LinearCamera>().enabled = false;
                    }

                    currentIndex = 0;
                }

            }
        }

    }

    IEnumerator WaitBeforeLaunch(float delay)
    {
        yield return new WaitForSeconds(delay);
        launch = true;
    }
}
