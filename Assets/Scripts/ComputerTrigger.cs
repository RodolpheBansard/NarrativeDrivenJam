using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTrigger : MonoBehaviour
{

    public SpriteRenderer sprite;
    public GameObject computerScreen;

    private void Start()
    {
        sprite.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            sprite.enabled = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            sprite.enabled = false;
            computerScreen.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && sprite.isVisible)
        {
            computerScreen.SetActive(!computerScreen.activeInHierarchy);
        }
    }
}
