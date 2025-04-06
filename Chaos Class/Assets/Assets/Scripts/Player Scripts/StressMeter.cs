using UnityEngine;
using UnityEngine.UI;
using System;

public class StressMeter : MonoBehaviour
{
    public Image AddStress;
    private float LevelofStress = 0f;
    public float RateofIncrease = 0f;
    public float MaxAmountofStress = 1f;

    public GameObject Gameoverpanel;
    public Gamestate Gamestatemanager;
    public string message = "Game Over";
    public delegate void NotificationHandler(string message);
    public event NotificationHandler OnNotify;

    void Update()
    {

        LevelofStress += RateofIncrease * Time.deltaTime;
        LevelofStress = Mathf.Clamp(LevelofStress, 0f, MaxAmountofStress);


        AddStress.fillAmount = LevelofStress;


        if (LevelofStress >= MaxAmountofStress)
        {
            Debug.Log("Your stress meter is maxed out");
            Gameover();
        }
    }

    void Gameover()
    {
        Notify();
        Gameoverpanel.SetActive(true);
        Cursor.visible = true;       // Show the cursor
        Cursor.lockState = CursorLockMode.None;


        Time.timeScale = 0f; // Pause the game
        Debug.Log("Game Over! Game is now paused.");
        
    }


    public void IncreaseStress(float amount)
    {
        LevelofStress += amount;
        LevelofStress = Mathf.Clamp(LevelofStress, 0f, MaxAmountofStress);
    }

    public void DecreaseStress(float amount)
    {
        LevelofStress -= amount;
        LevelofStress = Mathf.Clamp(LevelofStress, 0f, MaxAmountofStress);
    }
    public void Notify()
    {
        OnNotify?.Invoke("Game Over!");
    }
}