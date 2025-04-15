using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }

    private AudioSource audioSource;

    public AudioClip misbehave;
    public AudioClip question;
    public AudioClip chalkDraw;
    public AudioClip errorAudio;
    public AudioClip correctAudio;
    public AudioClip audio911;
    public AudioClip dialSound;
    public AudioClip busyDial;
    public AudioClip reprimand;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMisbehave()
    {
        PlaySFX(misbehave);
    }

    public void PlayQuestion()
    {
        PlaySFX(question);
    }

    public void PlayErrorAudio()
    {
        PlaySFX(errorAudio);
    }

    public void PlayCorrectAudio()
    {
        PlaySFX(correctAudio);
    }

    public void PlayChalkDraw()
    {
        PlaySFX(chalkDraw);
    }

    public void Play911()
    {
        PlaySFX(audio911);
    }

    public void PlayDial()
    {
        PlaySFX(dialSound);
    }

    public void PlayBusyDial()
    {
        PlaySFX(busyDial);
    }

    public void PlayReprimand()
    {
        PlaySFX(reprimand);
    }

    private void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }

}
