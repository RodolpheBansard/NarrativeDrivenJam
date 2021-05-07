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

    public AudioClip openSound;
    public AudioClip getItemSound;

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
            FindObjectOfType<AudioSource>().PlayOneShot(openSound, .8f);
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
                StartCoroutine(FindItem(item_peluche));
                codeDialog.gameObject.SetActive(false);
                pelucheDialog.enabled = true;
            }
            if (compteur == 2)
            {
                pelucheDialog.gameObject.SetActive(false);
                placardVideDialog.enabled = true;
            }
            if (compteur == 3)
            {
                StartCoroutine(FindItem(item_socks));
                placardVideDialog.gameObject.SetActive(false);
                chaussetteDialog.enabled = true;
            }
            if (compteur == 4)
            {
                chaussetteDialog.gameObject.SetActive(false);
                placardVideDialog2.enabled = true;
            }
            if (compteur == 5)
            {
                StartCoroutine(FindItem(item_tnt));
                placardVideDialog2.gameObject.SetActive(false);
                tntDialog.enabled = true;
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

    IEnumerator FindItem(GameObject item)
    {
        yield return new WaitForSeconds(.3f);
        FindObjectOfType<AudioSource>().PlayOneShot(getItemSound, .7f);
        item.SetActive(true);
    }
}
