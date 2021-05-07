using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDragon : MonoBehaviour
{
    public List<Transform> waypoints;
    public Transform shootPoint;
    public float moveSpeed = 3;

    public GameObject firePrefab;

    private int randomIndex;

    private int shootCompteur = 0;
    private bool canMove = true;


    void Start()
    {
        randomIndex = Random.Range(0, waypoints.Count - 1);
        transform.position = waypoints[randomIndex].position;
    }


    void Update()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[randomIndex].position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[randomIndex].position)
            {
                randomIndex = Random.Range(0, waypoints.Count - 1);
                shootCompteur++;
                if (shootCompteur == 3)
                {
                    StartCoroutine(ShootPlayer());
                }

            }
        }
    }

    IEnumerator ShootPlayer()
    {
        canMove = false;
        gameObject.GetComponent<Animator>().SetTrigger("puff");
        yield return new WaitForSeconds(.6f);
        GameObject bullet = Instantiate(firePrefab, shootPoint);
        bullet.transform.parent = null;
        yield return new WaitForSeconds(.4f);
        canMove = true;
        shootCompteur = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.parent.gameObject.GetComponent<PlayerController>()){
            FindObjectOfType<PlayerController>().takeHit(1);
        }
    }
}
