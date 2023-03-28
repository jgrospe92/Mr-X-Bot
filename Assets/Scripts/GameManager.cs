using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager instance;

    private int currentLevelIndex;

    public int scorePerLevel = 0;
    private int score = 0;
    public Text ScoreText;

    public static GameManager Instance
    {
      get { if (instance == null) { instance = new GameManager(); } return instance; }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        ScoreText.color = Color.yellow;
    }

  

    public void NextLevel()
    {
        scorePerLevel = score;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        score = scorePerLevel;
        displayScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void UpdateScore(int value)
    {
        score += value;
        ScoreText.text = "SCORE : " + score;
       
    }

    public void displayScore()
    {
        ScoreText.text = "SCORE : " + score;
    }

    public int GetScore()
    {
        return score;
    }

}
