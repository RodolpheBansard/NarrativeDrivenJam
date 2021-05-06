using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Digicode : MonoBehaviour
{

    public Dialog codeDialog;
    private string solution = "9372";

    public TMP_Text displayText;

    public List<GameObject> placards;

    public AudioClip buttonSound;
    public AudioClip rightCodeSound;
    public AudioClip wrongCodeSound;

    

    private void Start()
    {
        displayText.text = "";
    }

    IEnumerator CheckInput()
    {
        if (displayText.text == solution)
        {
            displayText.color = Color.green;
            FindObjectOfType<AudioSource>().PlayOneShot(rightCodeSound, .2f);
            codeDialog.enabled = true;
            yield return new WaitForSeconds(7);
            foreach(GameObject placard in placards)
            {
                placard.SetActive(true);
            }
            gameObject.SetActive(false);


        }        
        else
        {
            FindObjectOfType<AudioSource>().PlayOneShot(wrongCodeSound, .2f);
            displayText.color = Color.red; 
            yield return new WaitForSeconds(2);
            displayText.text = "";
            displayText.color = Color.white;
        }

    }

    public void add1()
    {
        FindObjectOfType<AudioSource>().PlayOneShot(buttonSound, .2f);
        displayText.text += "1";
        
    }
    public void add2()
    {
        FindObjectOfType<AudioSource>().PlayOneShot(buttonSound, .2f);
        displayText.text += "2";
        if (displayText.text.Length >= 4)
        {
            StartCoroutine(CheckInput());
        }
    }
    public void add3()
    {
        FindObjectOfType<AudioSource>().PlayOneShot(buttonSound, .2f);
        displayText.text += "3";
        if (displayText.text.Length >= 4)
        {
            StartCoroutine(CheckInput());
        }
    }
    public void add4()
    {
        FindObjectOfType<AudioSource>().PlayOneShot(buttonSound, .2f);
        displayText.text += "4";
        if (displayText.text.Length >= 4)
        {
            StartCoroutine(CheckInput());
        }
    }
    public void add5()
    {
        FindObjectOfType<AudioSource>().PlayOneShot(buttonSound, .2f);
        displayText.text += "5";
        if (displayText.text.Length >= 4)
        {
            StartCoroutine(CheckInput());
        }
    }
    public void add6()
    {
        FindObjectOfType<AudioSource>().PlayOneShot(buttonSound, .2f);
        displayText.text += "6";
        if (displayText.text.Length >= 4)
        {
            StartCoroutine(CheckInput());
        }
    }
    public void add7()
    {
        FindObjectOfType<AudioSource>().PlayOneShot(buttonSound, .2f);
        displayText.text += "7";
        if (displayText.text.Length >= 4)
        {
            StartCoroutine(CheckInput());
        }
    }
    public void add8()
    {
        FindObjectOfType<AudioSource>().PlayOneShot(buttonSound, .2f);
        displayText.text += "8";
        if (displayText.text.Length >= 4)
        {
            StartCoroutine(CheckInput());
        }
    }
    public void add9()
    {
        FindObjectOfType<AudioSource>().PlayOneShot(buttonSound, .2f);
        displayText.text += "9";
        if (displayText.text.Length >= 4)
        {
            StartCoroutine(CheckInput());
        }
    }
}
