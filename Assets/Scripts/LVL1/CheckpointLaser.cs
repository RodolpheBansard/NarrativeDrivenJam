using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointLaser : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            player.UpdateCheckpoint();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
