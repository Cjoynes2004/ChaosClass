using UnityEngine;
using UnityEngine.UI;

public class StressMeter : MonoBehaviour //handles stress, including its rate of increase, the level, max amount, and increase
{
    public Image AddStress;
    private float LevelofStress = 0f;
    public float RateofIncrease = 0.1f;
    public float MaxAmountofStress = 1f;

    public GameObject Gameoverpanel;
    public Gamestate Gamestatemanager;

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
        Cursor.visible = true;       // Show the cursor
        Cursor.lockState = CursorLockMode.None;


        Time.timeScale = 0f; // Pause the game
        Debug.Log("Game is over.");
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