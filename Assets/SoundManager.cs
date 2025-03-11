using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; 

    public AudioSource audioSource;
    public AudioClip errorSound;
    public AudioClip failureSound;

    void Awake()
    {
        
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayErrorSound()
    {
        if (errorSound != null)
            audioSource.PlayOneShot(errorSound);
    }

    public void PlayFailureSound()
    {
        if (failureSound != null)
            audioSource.PlayOneShot(failureSound);
    }

    
    public void SimulateFailure(bool playerHasFailed, bool playerMadeAnError)
    {
        if (playerHasFailed)
        {
            Debug.Log("Player has failed! Playing failure sound.");
            PlayFailureSound();
        }

        if (playerMadeAnError)
        {
            Debug.Log("Player made an error! Playing error sound.");
            PlayErrorSound();
        }
    }
}

