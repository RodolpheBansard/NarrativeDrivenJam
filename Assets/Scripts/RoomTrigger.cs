using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GameObject nextRoom;
    public PlayerController player;
    public BoxCollider2D collider;

    public GameObject level1;
    public Animator level1Animator;

    public GameObject level2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            if(level1 != null && nextRoom == level2)
            {
                level1Animator.SetTrigger("disapear");
                StartCoroutine(WaitLevel());
            }
            nextRoom.SetActive(true);
            player.UpdateCheckpoint();
            collider.enabled = false;
        }
        

    }

    IEnumerator WaitLevel()
    {
        
        yield return new WaitForSeconds(.001f); 
        level2.SetActive(false);
        player.GetComponent<Rigidbody2D>().simulated = false;
        yield return new WaitForSeconds(1.2f);
        player.GetComponent<Rigidbody2D>().simulated = true;
        level1.SetActive(false);
        level2.SetActive(true);
    }
}
