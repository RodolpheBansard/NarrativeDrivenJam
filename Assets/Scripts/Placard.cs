using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placard : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator animator;
    public GameObject item_peluche;
    public GameObject item_socks;
    public GameObject item_tnt;

    public bool opened = false;

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
            opened = true;
            animator.SetTrigger("openDoor");
            sprite.gameObject.SetActive(false);
            int compteur = 0;
            foreach(Placard placard in FindObjectsOfType<Placard>())
            {
                if (placard.opened)
                {
                    compteur++;
                }
            }
            if(compteur == 1)
            {
                item_peluche.SetActive(true);
            }
            if (compteur == 2)
            {
                item_socks.SetActive(true);
            }
            if (compteur == 3)
            {
                item_tnt.SetActive(true);
                FindObjectOfType<PlayerController>().SetHasTnt();
            }
        }
    }
}
