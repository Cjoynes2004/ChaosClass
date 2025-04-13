using UnityEngine;
using UnityEngine.UI;
using System;
public class StressMeter : MonoBehaviour //handles stress, including its rate of increase, the level, max amount, and increase
{
    public Image AddStress;
    private float LevelofStress = 0f;
    public float RateofIncrease = 0.1f;
    public float MaxAmountofStress = 1f;

    public GameObject Gameoverpanel;
    public Gamestate Gamestatemanager;
    public ToggleUI toggler;
    public bool isGameOver;

    public event Action<string> OnNotify;
    void Update()
    {

        LevelofStress += RateofIncrease * Time.deltaTime; //Just a showcase that fills the stressmeter to activate the gameover menu
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
        Gameoverpanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        Debug.Log("Game Over! Game is now paused.");
        isGameOver = true;
        MusicManager.Instance.PlayGameOverMusic();
        OnNotify?.Invoke("Stress Maxed");
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

}