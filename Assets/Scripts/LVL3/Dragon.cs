using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public GameObject firePos;
    public GameObject fireDestination;

    public GameObject fireBallPrefab;

    public float speed;

    private Rigidbody2D rb;
    private GameObject fireball;


    // Start is called before the first frame update
    void Start()
    {
        fireball = Instantiate(fireBallPrefab, firePos.transform) as GameObject;
        rb = fireball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb != null && fireball != null)
        {
            Vector2 moveDirection = (fireDestination.transform.position - firePos.transform.position).normalized * speed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
        
    }
}
