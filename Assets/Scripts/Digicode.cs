using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Digicode : MonoBehaviour
{
    private string solution = "9372";

    public TMP_Text displayText;
    

    private void Start()
    {
        displayText.text = "";
    }

    private void Update()
    {
        if(displayText.text.Length >= 4)
        {
            StartCoroutine(CheckInput());
        }
    }

    IEnumerator CheckInput()
    {
        if (displayText.text == solution)
        {
            displayText.color = Color.green;
            yield return new WaitForSeconds(2);
            gameObject.SetActive(false);
        }
        else if (displayText.text == "7239")
        {
            displayText.color = Color.red;
            yield return new WaitForSeconds(2);
            displayText.text = "";
            displayText.color = Color.white;
        }
        else
        {
            displayText.color = Color.red; 
            yield return new WaitForSeconds(2);
            displayText.text = "";
            displayText.color = Color.white;
        }

    }

    public void add1()
    {
        displayText.text += "1";
    }
    public void add2()
    {
        displayText.text += "2";
    }
    public void add3()
    {
        displayText.text += "3";
    }
    public void add4()
    {
        displayText.text += "4";
    }
    public void add5()
    {
        displayText.text += "5";
    }
    public void add6()
    {
        displayText.text += "6";
    }
    public void add7()
    {
        displayText.text += "7";
    }
    public void add8()
    {
        displayText.text += "8";
    }
    public void add9()
    {
        displayText.text += "9";
    }
}
