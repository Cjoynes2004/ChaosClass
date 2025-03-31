using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gamestate : MonoBehaviour
{
    public bool Isgameover = false;  // Make sure this is public or use a property to get/set it

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f; // Ensure the game starts normally

    }

    public void Restartgame()
    {
        Debug.Log("Restart button clicked!");


        Time.timeScale = 1f; // Ensure the game is not paused
        SceneManager.LoadScene("classroom");



    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu"); // Replace with your menu scene's exact name
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

}
