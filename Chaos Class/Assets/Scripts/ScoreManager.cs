using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI Score;
    private int currentScore;
    public int RateofIncrease = 10;
    public int highest_score;
    private float scoreCounter;
    private string highScore = "high_score.txt";
    public GameObject Gameoverpanel;
    public Gamestate Gamestatemanager;
    public StressMeter publisher;
    void Update()
    {
        Score.text = currentScore.ToString();
        //IncreaseScore();
        Debug.Log("printing");
        //IncreaseScore();
    }
    void Start()
    {
        ResetGame();
        currentScore = 0;
        Score.text = currentScore.ToString();
        if (publisher != null)
        {
            publisher.OnNotify += Gameover;
            Debug.Log("Subscribed to StressMeter OnNotify event.");
        }
        else
        {
            Debug.LogWarning("Publisher (StressMeter) is not assigned.");
        }
        if (File.Exists(highScore))
        {
            fetchHighScore(highScore);
        }
        else
        {
            writeToFile(highScore, currentScore);
            fetchHighScore(highScore);
        }
    }
    void Gameover(string message)
    {
        if (currentScore >= highest_score)
        {
            writeToFile(highScore, currentScore);
        }
    }
    public void IncreaseScore(int score)
    {

        currentScore += score;
        //currentScore = Mathf.Clamp(currentScore, 0, int.MaxValue);
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
    public void writeToFile(string highScore, int currentScore)
    {
        using (StreamWriter writer = new StreamWriter(highScore))
        {
            writer.WriteLine(currentScore.ToString());
        }
    }
    public void ResetGame()
    {
        Gameoverpanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
                             // Reset other necessary game parameters here
    }
    public int getHighestScore()
    {
        fetchHighScore(highScore);
        return highest_score;
    }

}
