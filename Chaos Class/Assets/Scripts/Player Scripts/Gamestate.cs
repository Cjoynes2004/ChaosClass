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
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }
}