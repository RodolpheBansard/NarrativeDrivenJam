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

    public AudioClip openDoorSound;
    public AudioClip robotRoarSound;

    private bool isActive = false;

    private void Start()
    {
        sprite.enabled = false;
        computerScreen.GetComponent<Canvas>().enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            if (isActive)
            {
                computerScreen.GetComponent<Canvas>().enabled = true;
            }
            sprite.enabled = true;
            
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            sprite.enabled = false;
            computerScreen.GetComponent<Canvas>().enabled = false;
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
                computerScreen.GetComponent<Canvas>().enabled = !computerScreen.GetComponent<Canvas>().isActiveAndEnabled;
                //computerScreen.SetActive(!computerScreen.activeInHierarchy);
            }
            
        }
    }

    IEnumerator RevealRobot()
    {
        
        revealRobotDialog.enabled = true;
        yield return new WaitForSeconds(2);
        FindObjectOfType<AudioSource>().PlayOneShot(openDoorSound, .3f);
        doorAnimator.SetTrigger("open");
        transitionLevel3.SetActive(true);
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioSource>().PlayOneShot(robotRoarSound, 2f);
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<MusicPlayer>().playTheChase();
    }
}
