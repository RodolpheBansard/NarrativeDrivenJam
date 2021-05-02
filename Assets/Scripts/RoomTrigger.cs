using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GameObject nextRoom;
    public PlayerController player;
    public BoxCollider2D collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            nextRoom.SetActive(true);
            player.UpdateCheckpoint();
            collider.enabled = false;
        }
        

    }
}
