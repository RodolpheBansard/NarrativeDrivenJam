using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public PlayerController player;
    public Transform playerPosLvl3;
    public CinemachineVirtualCamera normalCamera;
    public CinemachineVirtualCamera runningCamera;
    public LVL3Sequencer LVL3Sequencer;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    private bool isRunner = false;


    private void Awake()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            ResetRunner();
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    

    public void Level3()
    {
        isRunner = true;
    }

    private void ResetRunner()
    {
        normalCamera.gameObject.SetActive(false);
        runningCamera.gameObject.SetActive(true);
        LVL3Sequencer.gameObject.SetActive(true);
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(true);
        player.SetIsRunning();
        player.GetComponent<Rigidbody2D>().gravityScale = 5;
        player.transform.position = playerPosLvl3.position;
    }
}
