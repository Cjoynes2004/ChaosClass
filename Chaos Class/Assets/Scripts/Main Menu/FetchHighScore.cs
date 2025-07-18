using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class FetchHighScore : MonoBehaviour
{
    private string highScore = "high_score.txt";
    public TextMeshProUGUI highScoreDisplay;

    void Start()
    {
        if (File.Exists(highScore))
        {
            fetchHighScore(highScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fetchHighScore(string highScore)
    {
        using (StreamReader reader = new StreamReader(highScore))
        {
            string check_highest_score;
            while ((check_highest_score = reader.ReadLine()) != null)
            {
                 highScoreDisplay.text = "High Score: " + check_highest_score;
            }
        }
    }
}
