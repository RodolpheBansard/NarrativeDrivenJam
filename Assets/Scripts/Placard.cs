using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placard : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator animator;

    private void Start()
    {
        sprite.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            sprite.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            sprite.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && sprite.isVisible)
        {
            animator.SetTrigger("openDoor");
            sprite.gameObject.SetActive(false);
        }
    }
}
