using UnityEngine;

public class GameEvents : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Error happened! Playing error sound.");
            SoundManager.instance.PlayErrorSound();
        }

        
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Failure occurred! Playing failure sound.");
            SoundManager.instance.PlayFailureSound();
        }
    }
}

