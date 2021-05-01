using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CameraSequence : MonoBehaviour
{
    public List<Light2D> cameras;


    // Start is called before the first frame update
    void Start()
    {
        if(cameras.Count > 1)
        {
            foreach (Light2D camera in cameras)
            {
                camera.gameObject.SetActive(false);
            }
            StartCoroutine(Sequencing());
        }
        else
        {
            StartCoroutine(Blink());
        }
        
        
    }

    IEnumerator Sequencing()
    {
        while (true)
        {
            for (int i = 0; i < cameras.Count; i++)
            {
                if (i == 0)
                {
                    cameras[cameras.Count - 1].gameObject.SetActive(false);
                }
                else
                {
                    cameras[i-1].gameObject.SetActive(false);
                }

                cameras[i].gameObject.SetActive(true);
                yield return new WaitForSeconds(1);
                cameras[i].gameObject.SetActive(false);

                if (i == cameras.Count - 1)
                {
                    cameras[0].gameObject.SetActive(true);
                }
                else
                {
                    cameras[i+1].gameObject.SetActive(true);
                }
            }
        }
        
    }
    IEnumerator Blink()
    {
        while (true)
        {
            cameras[0].gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            cameras[0].gameObject.SetActive(false);
            yield return new WaitForSeconds(1);
            
        }

    }
}
