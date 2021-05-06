using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRobot : MonoBehaviour
{
    public List<Transform> waypoints;
    public List<Transform> shootPoints;
    public float moveSpeed = 3;

    public GameObject bulletPrefab;

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
                if (shootCompteur == 5)
                {
                    StartCoroutine(ShootPlayer());
                }

            }
        }        
    }

    IEnumerator ShootPlayer()
    {
        canMove = false;
        gameObject.GetComponent<Animator>().SetTrigger("shoot");
        yield return new WaitForSeconds(.4f);
        foreach(Transform shootpoint in shootPoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootpoint);
            bullet.transform.parent = null;
        }
        yield return new WaitForSeconds(.4f);
        canMove = true;
        shootCompteur = 0;
    }
}
