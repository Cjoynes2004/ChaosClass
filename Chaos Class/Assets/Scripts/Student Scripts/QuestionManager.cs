using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public TextAsset questionFile;
    public Button[] answerButtons;
    public TMP_Text questionText;
    public PlayerMovement player;
    public StressMeter stressMeter;
    public ToggleUI toggler;
    public ScoreManager scoreManager;
    private int currIndex = 0;
    private List<Question> questions = new List<Question>();
    private int correctAnswer = 0;


    // Start is called before the first frame update
    void Start()
    {
        LoadQuestions();
        gameObject.SetActive(false);
    }

    void LoadQuestions()
    {
        string[] lines = questionFile.text.Split('\n');

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue; // Skip empty lines

            string[] parts = line.Split('|'); // Change delimiter if using CSV
            if (parts.Length == 5) // Question + 4 Answers
            {
                Question q = new Question(currIndex, parts[0], parts[1], new string[] { parts[2], parts[3], parts[4] });
                questions.Add(q);
                currIndex++;
            }
        }
    }

    public void AskQuestion()
    {
        Question question = ReturnQuestion();

        List<string> allAnswers = new List<string>(question.wrongAnswers);
        correctAnswer = Random.Range(0, 4);
        allAnswers.Insert(correctAnswer, question.correctAnswer);
        questionText.text = question.questionText.ToString();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = allAnswers[i]; 
            int index = i; 
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
        toggler.SwitchUI();
        player.canMove = false;
        gameObject.SetActive(true);
    }

    void CheckAnswer(int selectedIndex)
    {
        if (selectedIndex == correctAnswer)
        {
            Debug.Log("Correct Answer! Points awarded.");
            stressMeter.DecreaseStress((float)0.5);
            scoreManager.IncreaseScore(100);
        }
        else
        {
            Debug.Log("Wrong Answer!");
        }
        gameObject.SetActive(false);
        toggler.SwitchUI();
        player.canMove = true;
    }

        Question ReturnQuestion() 
    {
        int questionValue = Random.Range(0, questions.Count);
        for (int i = 0; i < questions.Count; i++)
        {
            if (questions[i].questionIndex == questionValue)
            {
                return questions[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Question
{
    public int questionIndex;
    public string questionText;
    public string correctAnswer;
    public string[] wrongAnswers;

    public Question(int qI, string q, string correct, string[] wrong)
    {
        questionIndex = qI;
        questionText = q;
        correctAnswer = correct;
        wrongAnswers = wrong;
    }
}
