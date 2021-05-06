using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL3Sequencer : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<Dialog> dialogs;

    public GameObject robotContainer;
    public GameObject dragonContainer;

    private bool isconverging = false;

    private void Start()
    {
        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        

        dialogs[0].enabled = true;
        yield return new WaitForSeconds(dialogs[0].getLength());
        robotContainer.SetActive(true);
        yield return new WaitForSeconds(5);

        dialogs[1].enabled = true;
        yield return new WaitForSeconds(dialogs[1].getLength());
        dragonContainer.SetActive(true);
        yield return new WaitForSeconds(5);

        dialogs[2].enabled = true;
        yield return new WaitForSeconds(dialogs[2].getLength());
        enemies[0].GetComponent<LinearCamera>().enabled = true;
        yield return new WaitForSeconds(4);

        dialogs[3].enabled = true;
        yield return new WaitForSeconds(dialogs[3].getLength());
        enemies[1].GetComponent<Dragon>().enabled = true;
        yield return new WaitForSeconds(3);

        dialogs[4].enabled = true;
        yield return new WaitForSeconds(dialogs[4].getLength());
        enemies[2].GetComponent<LinearCamera>().enabled = true;
        yield return new WaitForSeconds(5);

        dialogs[5].enabled = true;
        yield return new WaitForSeconds(dialogs[5].getLength());
        enemies[3].GetComponent<LinearCamera>().enabled = true;
        yield return new WaitForSeconds(5);

        dialogs[6].enabled = true;
        dialogs[7].enabled = true;
        yield return new WaitForSeconds(dialogs[6].getLength());

        isconverging = true;

        yield return new WaitForSeconds(5);
        isconverging = false;

        dialogs[8].enabled = true;

    }

    private void Update()
    {
        if (isconverging)
        {
            robotContainer.transform.Translate(Vector2.right * Time.deltaTime);
            dragonContainer.transform.Translate(Vector2.left * Time.deltaTime);

        }
    }


}
