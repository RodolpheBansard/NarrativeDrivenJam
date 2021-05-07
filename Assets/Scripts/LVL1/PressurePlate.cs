using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public List<GameObject> lasers;

    public Sprite spriteNotClicked;
    public Sprite spriteClicked;
    public AudioClip clickAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            FindObjectOfType<AudioSource>().PlayOneShot(clickAudio, .7f);
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteClicked;
            foreach (GameObject laser in lasers)
            {
                laser.SetActive(!laser.activeInHierarchy);                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteNotClicked;
        }
    }
}
