using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl4Sequencer : MonoBehaviour
{
    public PlayerController player;
    public GameObject playerHealthBar;

    public Transform fusionPoint;

    private void Start()
    {
        player.GetComponent<Animator>().SetBool("level4", true);
        player.SetHealthBar();
    }

    IEnumerator SpawnBosses()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator FusionBosses()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator Epilogue()
    {
        yield return new WaitForSeconds(1);
    }
}
