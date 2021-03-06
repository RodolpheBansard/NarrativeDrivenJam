using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip spyOnDuty;
    public AudioClip theChase;
    public AudioClip bossMusic;
    public AudioClip ourStoryMusic;

    public bool isPlayingBossMusic = false;

    public AudioSource audioSource;

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        audioSource.clip = spyOnDuty;
        audioSource.Play();
    }

    public void playTheChase()
    {
        audioSource.clip = theChase;
        audioSource.Play();
    }

    public void playBossMusic()
    {
        audioSource.clip = bossMusic;
        isPlayingBossMusic = true;
        audioSource.Play();
    }

    public void playOurStory()
    {
        audioSource.clip = ourStoryMusic;
        audioSource.Play();
    }
}
