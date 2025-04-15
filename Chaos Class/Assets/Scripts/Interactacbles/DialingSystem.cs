using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialingSystem : MonoBehaviour
{
    public Button[] numberButtons;
    public Button callButton;
    public ToggleUI toggler;
    public PlayerMovement player;
    public StressMeter stress;
    public ScoreManager score;
    public SFXManager sFXManager;

    private string numberDialed = "";
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        foreach (Button btn in numberButtons)
        {
            string digit = btn.GetComponentInChildren<TextMeshProUGUI>().text;
            btn.onClick.AddListener(() => AddDigit(digit));
        }

        callButton.onClick.AddListener(MakeCall);
    }

    void AddDigit(string digit)
    {
        numberDialed += digit;
        sFXManager.PlayDial();
    }

    void MakeCall()
    {
        Debug.Log("Calling: " + numberDialed);

        if (numberDialed == "911")
        {
            Debug.Log("Emergency services triggered!");
            score.IncreaseScore(500);
            stress.IncreaseStress((float)0.5);
            sFXManager.Play911();
        }
        else
        {
            sFXManager.PlayBusyDial();
        }

        // Reset number after call
        numberDialed = "";
        gameObject.SetActive(false);
        toggler.SwitchUI();
        player.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
