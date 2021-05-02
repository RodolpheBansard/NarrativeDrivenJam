using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentTrigger : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Transform exitVent;
    public PlayerController player;

    private void Start()
    {
        sprite.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        sprite.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && sprite.isVisible)
        {
            StartCoroutine(player.WaitVent(exitVent));
        }
    }

    
}
