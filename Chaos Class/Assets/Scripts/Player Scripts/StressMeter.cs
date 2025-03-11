using UnityEngine;
using UnityEngine.UI;

public class StressMeter : MonoBehaviour
{
    public Image AddStress; 
    private float LevelofStress = 0f; 
    public float RateofIncrease = 0.1f;
    public float MaxAmountofStress = 1f; 

    void Update()
    {
        
        LevelofStress += RateofIncrease * Time.deltaTime;
        LevelofStress = Mathf.Clamp(LevelofStress, 0f, MaxAmountofStress);

        
        AddStress.fillAmount = LevelofStress;

        
        if (LevelofStress >= MaxAmountofStress)
        {
            Debug.Log("Your stress meter is maxed out");
        }
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
