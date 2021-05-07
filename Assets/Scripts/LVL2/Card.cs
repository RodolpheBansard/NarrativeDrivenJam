using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public List<GameObject> items;
    public GameObject card;

    public AudioClip getItemSound;

    private int compteur = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            foreach(GameObject item in items)
            {
                item.SetActive(false);
            }
            card.SetActive(true);
            collision.GetComponent<PlayerController>().hasCard = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            FindObjectOfType<AudioSource>().PlayOneShot(getItemSound, .8f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
