using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * -15;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(!collision.GetComponent<Bullet>() && collision.transform.parent.gameObject.GetComponent<PlayerController>())
        {
            print("touché");
        }
    }
}
