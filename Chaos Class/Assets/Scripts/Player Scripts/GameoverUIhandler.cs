using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameOverUIHandler : MonoBehaviour
{
    public Button restartButton;
    public Button menuButton;

    void Start()
    {
        restartButton.onClick.AddListener(() => Gamestate.Instance.Restartgame()); //Allows for the restart and load menu buttons to be linked to the gameover ui
        menuButton.onClick.AddListener(() => Gamestate.Instance.LoadMenu());
    }
}
