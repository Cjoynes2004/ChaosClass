using UnityEngine;

public class PhoneDialer : MonoBehaviour
{
    public string correctNumber = "911"; 

    public void DialNumber(string playerInput)
    {
        if (playerInput == correctNumber)
        {
            Debug.Log("Correct number dialed!");
            
        }
        else
        {
            Debug.Log("Incorrect number! Playing failure sound.");
            SoundManager.instance.PlayFailureSound();
        }
    }
}
