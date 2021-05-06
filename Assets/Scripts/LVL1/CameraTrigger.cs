using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public PlayerController player;
    public AudioClip caughtSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.parent.gameObject.GetComponent<PlayerController>() != null || collision.gameObject.GetComponent<PlayerController>())
        {
            FindObjectOfType<AudioSource>().PlayOneShot(caughtSound, .2f);
            player.Detected();
        }
        
    }
}
