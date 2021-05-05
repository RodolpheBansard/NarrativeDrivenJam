using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionLVL3 : MonoBehaviour
{

    public PlayerController player;
    public Rigidbody2D rbPlayer;
    public BoxCollider2D hitDetectionBox;

    public GameObject level2;
    public GameObject level3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            rbPlayer.gravityScale = 100;
        }
    }

    private void Update()
    {
        if (hitDetectionBox.IsTouchingLayers(LayerMask.GetMask("ground")))
        {
            player.SetIsRunning();
        }
    }
}
