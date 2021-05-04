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
                currentIndex++;
                if (currentIndex == waypoints.Count)
                {
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
