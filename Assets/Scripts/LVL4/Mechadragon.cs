using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechadragon : MonoBehaviour
{
    public List<Transform> waypoints;
    public List<Transform> shootPoints;
    public Transform firePoint;
    public float moveSpeed = 6;

    public GameObject firePrefab;
    public GameObject bulletPrefab;

    public HealthBar healthBar = null;
    public int maxHealth = 5;
    public int currentHealth = 0;

    public Transform spawnPoint;
    public GameObject deathVfx;

    public AudioClip bossHurtSound;
    public AudioClip fireSound;
    public AudioClip robotShootSound;

    private int randomIndex;

    private int shootCompteur = 0;
    private bool canMove = true;
    private bool dead = false;


    void Start()
    {

        transform.position = spawnPoint.position;
    }


    void Update()
    {
        if (canMove && !dead)
        {            
            transform.position = Vector2.MoveTowards(transform.position, waypoints[randomIndex].position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[randomIndex].position)
            {
                randomIndex = Random.Range(0, waypoints.Count - 1);
                shootCompteur++;
                if (shootCompteur == 2)
                {
                    int randomNumber = Random.Range(0, 2);
                    if (randomNumber == 0)
                    {
                        StartCoroutine(FireToPlayer());
                    }
                    else if(randomNumber == 1)
                    {
                        StartCoroutine(ShootPlayer());
                    }
                }

            }
        }
    }

    IEnumerator FireToPlayer()
    {
        canMove = false;
        gameObject.GetComponent<Animator>().SetTrigger("puff");
        yield return new WaitForSeconds(.6f);
        FindObjectOfType<AudioSource>().PlayOneShot(fireSound, 1);
        GameObject bullet = Instantiate(firePrefab, firePoint);
        bullet.transform.parent = null;
        yield return new WaitForSeconds(.4f);
        canMove = true;
        shootCompteur = 0;
    }

    IEnumerator ShootPlayer()
    {
        canMove = false;
        gameObject.GetComponent<Animator>().SetTrigger("shoot");
        yield return new WaitForSeconds(.4f);
        FindObjectOfType<AudioSource>().PlayOneShot(robotShootSound, 1);
        foreach (Transform shootpoint in shootPoints)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootpoint);
            bullet.transform.parent = null;
        }
        yield return new WaitForSeconds(.4f);
        canMove = true;
        shootCompteur = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<Bullet>() && !collision.GetComponent<Mechadragon>() && !collision.GetComponent<PlayerProjectile>() && collision.transform.parent.gameObject.GetComponent<PlayerController>())
        {
            FindObjectOfType<PlayerController>().takeHit(1);
        }
    }

    public void SetHealthBar()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);
    }
    public void takeHit(int value)
    {
        gameObject.GetComponent<Animator>().SetTrigger("Hit");
        FindObjectOfType<AudioSource>().PlayOneShot(bossHurtSound, 1);
        currentHealth -= value;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("dead");
            dead = true;
            GameObject vfx =  Instantiate(deathVfx, transform);
            vfx.transform.parent = null;
            Destroy(gameObject, .2f);
            FindObjectOfType<lvl4Sequencer>().StartEpilogue();
        }
    }
}
