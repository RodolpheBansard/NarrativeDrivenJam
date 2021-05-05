using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTrigger : MonoBehaviour
{

    public SpriteRenderer sprite;
    public GameObject computerScreen;
    public bool isDoor = false;
    public Animator doorAnimator;
    public Dialog revealRobotDialog;

    public GameObject transitionLevel3;

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
            if (isDoor & FindObjectOfType<PlayerController>().hasCard)
            {
                StartCoroutine(RevealRobot());
            }
            else
            {
                computerScreen.SetActive(!computerScreen.activeInHierarchy);
            }
            
        }
    }

    IEnumerator RevealRobot()
    {
        revealRobotDialog.enabled = true;
        yield return new WaitForSeconds(4);
        doorAnimator.SetTrigger("open");
        transitionLevel3.SetActive(true);
    }
}
