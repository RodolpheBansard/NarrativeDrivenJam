using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> spawnpointsLvl1;
    public CinemachineVirtualCamera camera;
    private int currentCheckpointIndex = 0;

    public float moveSpeed = 1;
    public float jumpSpeed;

    public Rigidbody2D rb;
    public Animator animator;
    public BoxCollider2D hitDetectionBox;

    private Vector2 movement;

    public bool canMove = false;
    public bool isRunning = false;

    public bool hasTnt = false;
    public bool hasCard = false;
    public bool canShoot = false;

    public AudioClip ventAudio;

    public HealthBar healthBar = null;
    public int maxHealth = 5;
    public int currentHealth=0;

    public GameObject playerProjectilePrefab=null;
    public Transform firePoint=null;


    void Update()
    {
        if (canMove && !isRunning)
        {
            animator.SetBool("isRunning", false);
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        if (isRunning)
        {
            animator.SetBool("isRunning", true);
            if (hitDetectionBox.IsTouchingLayers(LayerMask.GetMask("ground")))
            {
                animator.SetBool("isJumping", false);
                if (Input.GetKeyDown(KeyCode.Space) && !animator.GetBool("isSliding"))
                {
                    animator.SetBool("isJumping", true);
                    rb.velocity = new Vector2(0, jumpSpeed);
                }
                
            }
            else
            {
                animator.SetBool("isJumping", true);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                hitDetectionBox.size = new Vector2(1,0.7f);
                hitDetectionBox.offset = new Vector2(0,-0.4f);
                animator.SetBool("isSliding", true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                hitDetectionBox.size = new Vector2(1, 1.5f);
                hitDetectionBox.offset = Vector2.zero;
                animator.SetBool("isSliding", false);
            }

        }
        if (canShoot && Input.GetKeyDown(KeyCode.Space) && FindObjectOfType<lvl4Sequencer>())
        {
            GameObject projectile = Instantiate(playerProjectilePrefab, firePoint);
            projectile.transform.parent = null;
        }

    }

    private void FixedUpdate()
    {
        if (!isRunning)
        {
            if (movement == Vector2.zero)
            {
                animator.SetBool("isWalking", false);
            }
            else
            {
                animator.SetBool("isWalking", true);
            }

            rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
        }
        
    }

    public void drawingFinished()
    {
        canMove = true;
    }

    public void Detected()
    {
        animator.SetTrigger("death");        
        StartCoroutine(WaitDeath()); 

    }

    public void UpdateCheckpoint()
    {
        currentCheckpointIndex++;
    }
    public int GetCurrentCheckpointIndex()
    {
        return currentCheckpointIndex;
    }

    public IEnumerator WaitDeath()
    {
        canMove = false;
        movement = Vector2.zero;
        camera.m_Lens.FieldOfView = 50;
        
        yield return new WaitForSeconds(0.92f);
        transform.position = spawnpointsLvl1[currentCheckpointIndex].transform.position;        
        yield return new WaitForSeconds(1.83f);
        camera.m_Lens.FieldOfView = 70;

        canMove = true;
    }

    
    public IEnumerator WaitVent(Transform pos)
    {
        animator.SetTrigger("death");
        canMove = false;
        movement = Vector2.zero;
        camera.m_Lens.FieldOfView = 50;
        FindObjectOfType<AudioSource>().PlayOneShot(ventAudio, .2f);
        yield return new WaitForSeconds(0.92f);
        transform.position = pos.position;
        FindObjectOfType<AudioSource>().PlayOneShot(ventAudio, .2f);
        yield return new WaitForSeconds(1.83f);
        camera.m_Lens.FieldOfView = 70;
        canMove = true;
    }


    public void SetHasTnt()
    {
        hasTnt = true;
    }

    public bool GetHasTnt()
    {
        return hasTnt;
    }

    public void SetIsRunning()
    {
        this.isRunning = true;
    }

    public void StopPlayer()
    {
        movement = Vector2.zero;
        canMove = false;
    }
    public void UnlockPlayer()
    {
        canMove = true;
    }


    public void SetHealthBar()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);
    }
    public void takeHit(int value)
    {
        currentHealth -= value;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            StartCoroutine(DeathLevel4());
        }
    }

    IEnumerator DeathLevel4()
    {
        gameObject.GetComponent<Animator>().SetTrigger("death");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

}
