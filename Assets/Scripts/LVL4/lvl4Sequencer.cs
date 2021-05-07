using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl4Sequencer : MonoBehaviour
{
    public List<Dialog> dialogs;

    public PlayerController player;
    public GameObject playerHealthBar;

    public BossDragon dragon;
    public BossRobot robot;
    public Transform fusionPoint;

    public GameObject fusionVFX;

    public Mechadragon mechadragon;

    private bool fusioning;
    private int compteurBossDead = 0;

    private void Start()
    {
        player.GetComponent<Animator>().SetBool("level4", true);
        player.SetHealthBar();
        StartCoroutine(SpawnBosses());
    }




    private void Update()
    {
        if (fusioning)
        {
            dragon.transform.position = Vector2.MoveTowards(dragon.transform.position,fusionPoint.position,Time.deltaTime * 5);
            robot.transform.position = Vector2.MoveTowards(robot.transform.position,fusionPoint.position,Time.deltaTime * 5);

            if (dragon.transform.position == fusionPoint.position && robot.transform.position == fusionPoint.position)
            {
                StartCoroutine(FusionBosses());
                fusioning = false;
            }
        }
    }

    IEnumerator SpawnBosses()
    {
        dialogs[0].enabled = true;
        yield return new WaitForSeconds(5);
        robot.gameObject.SetActive(true);
        yield return new WaitForSeconds(7);
        dragon.gameObject.SetActive(true);
        yield return new WaitForSeconds(dialogs[0].getLength() - 12f);

        dialogs[1].enabled = true;
        dialogs[2].enabled = true;
        yield return new WaitForSeconds(dialogs[1].getLength());
        dragon.Move();
        robot.Move();
        player.canShoot = true;

    }

    IEnumerator FusionBosses()
    {
        dragon.gameObject.GetComponent<Animator>().SetTrigger("fusion");
        robot.gameObject.GetComponent<Animator>().SetTrigger("fusion");
        yield return new WaitForSeconds(1);
        dragon.gameObject.SetActive(false);
        robot.gameObject.SetActive(false);
        mechadragon.gameObject.SetActive(true);
       
    }

    IEnumerator Epilogue()
    {
        player.canShoot = false;
        dialogs[3].enabled = true;
        FindObjectOfType<MusicPlayer>().playOurStory();
        yield return new WaitForSeconds(1);
    }

    public void BossDead()
    {
        compteurBossDead++;
        if(compteurBossDead == 2)
        {
            fusioning = true;
        }
    }

    public void StartEpilogue()
    {
        StartCoroutine(Epilogue());
    }
}
