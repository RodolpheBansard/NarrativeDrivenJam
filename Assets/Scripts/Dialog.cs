using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject gameCam;
    public GameObject dialogCam;
    [SerializeField] float delayWriting;
    [SerializeField] float delayDeleting;
    [SerializeField] float delaybeforeDeleting;
    [SerializeField] float delaybeforeWriting;
    [TextArea(10,10)][SerializeField] List<string> story;

    public Text playerText;
    public Text otherText;
    public GameObject playerImage;
    public GameObject otherImage;
    public GameObject emotionImage;

    public List<Texture> emotionsSprites;
    public List<AudioClip> emotionsSound;

    public AudioClip playerSound;
    public AudioClip thanksSound;

    public bool isLastDialog;
    public bool imageToActivate;
    public List<GameObject> imagesToActivate;
    

    
    void Start()
    {

        dialogCam.SetActive(true);
        gameCam.SetActive(false);

        playerText.text = "";
        otherText.text = "";
        playerImage.SetActive(false);
        otherImage.SetActive(false);
        emotionImage.SetActive(false);

        StartCoroutine(WriteDialog());
    }

  

    IEnumerator WriteDialog()
    {
        int j = 0;
        while(j < story.Count)
        {
            int index = (int)char.GetNumericValue(story[j][0]);
            if (index == 1)
            {
                playerImage.SetActive(true);
                StartCoroutine(WriteText(story[j],playerText));
                if((int)char.GetNumericValue(story[j][1]) == 1)
                {
                    AudioSource.PlayClipAtPoint(thanksSound, Camera.main.transform.position + new Vector3(0, 0, 0), 1);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(playerSound, Camera.main.transform.position + new Vector3(0, 0, 0), 1);
                }                
                yield return new WaitForSeconds(story[j].Length * delayWriting + delaybeforeDeleting);
                //StartCoroutine(DeleteText(story[j],playerText));
                yield return new WaitForSeconds(story[j].Length * delayDeleting + delaybeforeWriting);
                playerText.text = "";
                j++;
                
            }
            else
            {
                otherImage.SetActive(true);
                emotionImage.SetActive(true);
                if(index == 5)
                {
                    emotionImage.GetComponent<RawImage>().texture = emotionsSprites[2];
                    AudioSource.PlayClipAtPoint(emotionsSound[2], Camera.main.transform.position + new Vector3(0, 0, 0), 1);
                    foreach(GameObject o in imagesToActivate)
                    {
                        o.SetActive(true);
                    }
                }
                else
                {
                    emotionImage.GetComponent<RawImage>().texture = emotionsSprites[index - 2];
                    AudioSource.PlayClipAtPoint(emotionsSound[index - 2], Camera.main.transform.position + new Vector3(0, 0, 0), 1);
                }                
                StartCoroutine(WriteText(story[j],otherText));
                yield return new WaitForSeconds(story[j].Length * delayWriting + delaybeforeDeleting);
                //StartCoroutine(DeleteText(story[j],otherText));
                yield return new WaitForSeconds(story[j].Length * delayDeleting + delaybeforeWriting);
                otherText.text = "";
                j++;
                
            }
        }
        foreach (GameObject o in imagesToActivate)
        {
            o.SetActive(false);
        }
        otherImage.SetActive(false);
        playerImage.SetActive(false);
        emotionImage.SetActive(false);
        player.StopPlayer(false);

        dialogCam.SetActive(false);
        gameCam.SetActive(true);

        if (isLastDialog)
        {
            FindObjectOfType<Scene>().LoadMenu();
        }
    }

    IEnumerator WriteText(string message, Text text)
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

    IEnumerator DeleteText(string message, Text text)
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
    public void Skip()
    {
        otherImage.SetActive(false);
        playerImage.SetActive(false);
        emotionImage.SetActive(false);
        player.StopPlayer(false);

        dialogCam.SetActive(false);
        gameCam.SetActive(true);
        Destroy(gameObject);
    }
}
