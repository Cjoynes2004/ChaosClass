using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TMPro;


public class HighScoreScreen : MonoBehaviour
{
    //public ScoreManager scoreManager = new ScoreManager;
    public TextMeshProUGUI Score;
    private int highest_score =  0;
    private string highScore = "high_score.txt";
    // Start is called before the first frame update
    void Start()
    {
        fetchHighScore(highScore);
        Score.text = "Highest Score: " + highest_score.ToString();
    }

    public void fetchHighScore(string highScore)
    {
        using (StreamReader reader = new StreamReader(highScore))
        {
            string check_highest_score;
            while ((check_highest_score = reader.ReadLine()) != null)
            {
                highest_score = int.Parse(check_highest_score);
            }
        }
    }
    void Update()
    {
        fetchHighScore(highScore);
        Score.text = "Highest Score: " + highest_score.ToString();
    }

}
