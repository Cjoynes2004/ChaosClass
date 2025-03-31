using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public string correctAnswer = "Unity"; 

    public void CheckAnswer(string playerAnswer)
    {
        if (playerAnswer == correctAnswer)
        {
            Debug.Log("Correct answer!");
            
        }
        else
        {
            Debug.Log("Wrong answer! Playing error sound.");
            SoundManager.instance.PlayErrorSound();
        }
    }
}
