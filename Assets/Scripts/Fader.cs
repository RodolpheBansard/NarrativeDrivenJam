using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    
    public void ReloadScene()
    {
        StartCoroutine(Reload());
    }


    IEnumerator Reload()
    {

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
