using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gamestate : MonoBehaviour
{
    public static Gamestate Instance; //Singleton instance so there is only game instance
    public bool Isgameover = false;

    void Start()
    {
        Time.timeScale = 1f; // Ensure the game starts normally

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); //Destroys any additonal instances
        }
        ResetGameState();
    }





    public void ResetGameState() //Resets the game parameters
    {
        Isgameover = false;
        Time.timeScale = 1f; 
        Cursor.visible = false; //Makes the cursor invisible, just a visual enhancement
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Restartgame()
    {
        Debug.Log("Restart button clicked!");


        Time.timeScale = 1f; // Ensure the game is not paused
        SceneManager.LoadScene("classroom");



    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }
}