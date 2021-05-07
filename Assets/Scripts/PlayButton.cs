using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        print("coucou");
    }
    private void OnMouseOver()
    {
        gameObject.GetComponent<Animator>().SetBool("isHovering", true);
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<Animator>().SetBool("isHovering", false);
    }
}
