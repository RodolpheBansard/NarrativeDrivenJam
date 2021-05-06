using Cinemachine;
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
    public LVL3Sequencer LVL3Sequencer;

    public CinemachineVirtualCamera normalCamera;
    public CinemachineVirtualCamera runningCamera;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            level3.SetActive(true);
            rbPlayer.gravityScale = 100;
            normalCamera.gameObject.SetActive(false);
            runningCamera.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (hitDetectionBox.IsTouchingLayers(LayerMask.GetMask("ground")))
        {
            LVL3Sequencer.gameObject.SetActive(true);
            rbPlayer.gravityScale = 5;
            player.SetIsRunning();
            level2.SetActive(false);
            FindObjectOfType<GameSession>().Level3();
        }
    }
}
