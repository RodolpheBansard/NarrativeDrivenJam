using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl4Sequencer : MonoBehaviour
{
    public PlayerController player;
    public GameObject playerHealthBar;

    private void Start()
    {
        player.GetComponent<Animator>().SetBool("level4", true);
        player.SetHealthBar();
    }
}
