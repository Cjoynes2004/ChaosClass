using UnityEngine;

public class AmbienceAndObjectSoundManager : MonoBehaviour
{
    public static AmbienceAndObjectSoundManager instance;  

    public AudioSource ambienceSource;    
    public AudioSource objectSource;      

    public AudioClip ambienceSound;       
    public AudioClip objectSound;         

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    
    public void PlayAmbienceSound()
    {
        if (ambienceSound != null)
        {
            ambienceSource.clip = ambienceSound;
            ambienceSource.loop = true;  
            ambienceSource.Play();
        }
    }

    
    public void StopAmbienceSound()
    {
        ambienceSource.Stop();
    }

    
    public void PlayObjectSound()
    {
        if (objectSound != null)
        {
            objectSource.PlayOneShot(objectSound);
        }
    }

    //added the following, needed in game

    void Start()
    {
        AmbienceAndObjectSoundManager.instance.PlayAmbienceSound();  
    }

    void StopAmbientSound()
    {
        AmbienceAndObjectSoundManager.instance.StopAmbienceSound();  
    }

    public class ObjectInteraction : MonoBehaviour
    {
        
        public void OnObjectPickUp()
        {
            AmbienceAndObjectSoundManager.instance.PlayObjectSound();  
        }
    }
}
