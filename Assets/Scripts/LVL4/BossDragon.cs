using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDragon : MonoBehaviour
{
    public List<Transform> waypoints;
    public Transform shootPoint;
    public float moveSpeed = 3;

    public GameObject firePrefab;

    public HealthBar healthBar = null;
    public int maxHealth = 5;
    public int currentHealth = 0;

    public AudioClip bossHurtSound;
    public AudioClip fireSound;

    private int randomIndex;

    private int shootCompteur = 0;
    private bool canMove = false;
    private bool dead = false;


    void Start()
    {
        transform.position = waypoints[3].position;
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
        FindObjectOfType<AudioSource>().PlayOneShot(fireSound, 1);
        GameObject bullet = Instantiate(firePrefab, shootPoint);
        bullet.transform.parent = null;
        yield return new WaitForSeconds(.4f);
        canMove = true;
        shootCompteur = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.GetComponent<PlayerProjectile>() && collision.transform.parent.gameObject.GetComponent<PlayerController>()){
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
            if (!dead)
            {
                FindObjectOfType<lvl4Sequencer>().BossDead();
            }
            dead = true;
            
        }
    }

    public void Move()
    {
        canMove = true;
    }
}
