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
        
    }

    public void Restartgame()
    {
        Debug.Log("Restart button clicked!");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
