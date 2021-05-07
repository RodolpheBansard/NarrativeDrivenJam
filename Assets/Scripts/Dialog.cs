using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
{
    public PlayerController player;
    [SerializeField] float delayWriting;
    [SerializeField] float delayDeleting;
    [SerializeField] float delaybeforeDeleting;
    [SerializeField] float delaybeforeWriting;
    [TextArea(10,10)][SerializeField] List<string> story;

    public TMP_Text narrator1Text = null;
    public TMP_Text narrator2Text = null;
    public TMP_Text narrator3Text = null;

    public AudioClip dialogSound = null;

    
    void Start()
    {
        FindObjectOfType<AudioSource>().PlayOneShot(dialogSound, .8f);
        if(narrator1Text != null)
        {
            narrator1Text.text = "";
        }
        if (narrator2Text != null)
        {
            narrator2Text.text = "";
        }
        if (narrator3Text != null)
        {
            narrator3Text.text = "";
        }

        StartCoroutine(WriteDialog());
    }

  

    IEnumerator WriteDialog()
    {
        player.StopPlayer();
        int j = 0;
        while(j < story.Count)
        {
            int index = (int)char.GetNumericValue(story[j][0]);
            if (index == 1)
            {
                StartCoroutine(WriteText(story[j], narrator1Text));                           
                yield return new WaitForSeconds(story[j].Length * delayWriting + delaybeforeDeleting);
                //StartCoroutine(DeleteText(story[j], narrator1Text));
                yield return new WaitForSeconds(story[j].Length * delayDeleting + delaybeforeWriting);
                narrator1Text.text = "";
                j++;
            }
            else if(index == 2)
            {
                StartCoroutine(WriteText(story[j], narrator2Text));
                yield return new WaitForSeconds(story[j].Length * delayWriting + delaybeforeDeleting);
                //StartCoroutine(DeleteText(story[j], narrator2Text));
                yield return new WaitForSeconds(story[j].Length * delayDeleting + delaybeforeWriting);
                narrator2Text.text = "";
                j++;
            }
            else
            {
                StartCoroutine(WriteText(story[j], narrator3Text));
                yield return new WaitForSeconds(story[j].Length * delayWriting + delaybeforeDeleting);
                //StartCoroutine(DeleteText(story[j], narrator3Text));
                yield return new WaitForSeconds(story[j].Length * delayDeleting + delaybeforeWriting);
                narrator3Text.text = "";
                j++;
            }
        }
        player.UnlockPlayer();
    }

    IEnumerator WriteText(string message, TMP_Text text)
    {
        string newMessage = "";
        int i;
        if ((int)char.GetNumericValue(message[1]) == 1)
        {
            i = 2;
        }
        else
        {
            i = 1;
        }
        

        while (i < message.Length)
        {            
            yield return new WaitForSeconds(delayWriting);
            newMessage += message[i];
            text.text = newMessage;
            i++;
        }
    }

    IEnumerator DeleteText(string message, TMP_Text text)
    {
        int x = message.Length;

        if ((int)char.GetNumericValue(message[1]) == 1)
        {
            while (x >= 2)
            {
                yield return new WaitForSeconds(delayDeleting);
                text.text = message.Substring(0, x);
                x--;
            }
        }
        else
        {
            while (x >= 1)
            {
                yield return new WaitForSeconds(delayDeleting);
                text.text = message.Substring(0, x);
                x--;
            }
        }
    }

    public float getLength()
    {
        float length = 0;
        foreach(string line in story)
        {
            length += line.Length * delayWriting + delaybeforeDeleting + line.Length * delayDeleting + delaybeforeWriting;
        }
        return length;
    }

    public void Skip()
    {
        player.UnlockPlayer();
        Destroy(gameObject);
    }
}
