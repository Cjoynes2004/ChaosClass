using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    public AudioClip menuTheme;
    public AudioClip mainTheme;
    public AudioClip gameOverTheme;
    public AudioClip misbehaveEffect;
    public AudioClip howtoplayTheme;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMenuTheme()
    {
        PlayClip(menuTheme);
    }

    public void PlayMainTheme()
    {
        PlayClip(mainTheme);
    }

    public void PlayGameOverMusic()
    {
        PlayClip(gameOverTheme);
    }
    public void PlayHowToPlayMusic()
    {
        PlayClip(howtoplayTheme);
    }
    private void PlayClip(AudioClip clip)
    {
        if (clip == null || audioSource.clip == clip) return;

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
