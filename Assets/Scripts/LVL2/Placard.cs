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

    public Dialog placardVideDialog;
    public Dialog placardVideDialog2;
    public Dialog chaussetteDialog;
    public Dialog pelucheDialog;
    public Dialog tntDialog;
    public Dialog codeDialog;

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
            ResetDialog();
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
                codeDialog.gameObject.SetActive(false);
                item_peluche.SetActive(true);
                pelucheDialog.enabled = true;
            }
            if (compteur == 2)
            {
                pelucheDialog.gameObject.SetActive(false);
                placardVideDialog.enabled = true;
            }
            if (compteur == 3)
            {
                placardVideDialog.gameObject.SetActive(false);
                item_socks.SetActive(true);
                chaussetteDialog.enabled = true;
            }
            if (compteur == 4)
            {
                chaussetteDialog.gameObject.SetActive(false);
                placardVideDialog2.enabled = true;
            }
            if (compteur == 5)
            {
                placardVideDialog2.gameObject.SetActive(false);
                tntDialog.enabled = true;
                item_tnt.SetActive(true);
                FindObjectOfType<PlayerController>().SetHasTnt();
            }

        }
    }

    private void ResetDialog()
    {
        placardVideDialog.enabled = false;
        chaussetteDialog.enabled = false;
        pelucheDialog.enabled = false;
        tntDialog.enabled = false;
    }
}
