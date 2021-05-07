using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * -15;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Mechadragon>() && !collision.GetComponent<PlayerProjectile>() && !collision.GetComponent<Bullet>() && !collision.GetComponent<BossRobot>() && collision.transform.parent.gameObject.GetComponent<PlayerController>())
        {
            FindObjectOfType<PlayerController>().takeHit(1);
        }
    }
}
