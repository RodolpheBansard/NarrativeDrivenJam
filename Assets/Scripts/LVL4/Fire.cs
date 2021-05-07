using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public BoxCollider2D collider;
    

    public void EnableCollider()
    {
        collider.enabled = true;
    }

    public void Extinguish()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.GetComponent<PlayerProjectile>() && collision.transform.parent.gameObject.GetComponent<PlayerController>()){

            FindObjectOfType<PlayerController>().takeHit(2);
        }
    }


}
