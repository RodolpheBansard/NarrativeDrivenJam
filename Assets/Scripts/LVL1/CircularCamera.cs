using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularCamera : MonoBehaviour
{
    public float RotateSpeed = 5f;
    public float Radius = 1f;

    public Transform centre;
    public float angle=0;

    private void Update()
    {

        angle += RotateSpeed * Time.deltaTime;

        Vector3 offset = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle),0) * Radius;
        transform.position = centre.position + offset;
    }
}
