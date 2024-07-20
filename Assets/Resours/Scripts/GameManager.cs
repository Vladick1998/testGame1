using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

//Скрипт содержит в себе информацию о score игрока так же в случае нового рекорда сохраняет его. Так же скрипт содержит код смены сцены.
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField]
    private ScoreScriptableObject maxScore;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public GameObject restartCanvas;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {

            score = value;
            scoreText.text = "Score: " + score;
        }

    }
    void Start()
    {
        gameManager = this;
    }
    public void Restart()
    {
        if (maxScore.score < score)
        {
            maxScore.score = score;
            restartText.text += "New record\n";
        }
        restartText.text = "Current score: "+ score;
        
        restartText.text += "\nMax Score: " + maxScore.score;
        restartCanvas.SetActive(true);
    }
    public void LoadNewScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }
}
