using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;

    public Image livesimagedisplay;
    public Text scoreText;
    public Text bestscoreText;
    public int score = 0;
    public int bestscore = 0;
    public GameObject titleScreen;
    public void Start()
    {
        bestscore = PlayerPrefs.GetInt("HighScore", 0);
        bestscoreText.text = "Best: " + bestscore;
    }
    public void UpdateLives(int currentlives)
    {
        livesimagedisplay.sprite = lives[currentlives];
    }

    public void UpdateScore()
    {
        
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void ShowTitle()
    {
       
        titleScreen.SetActive(true);
        if (bestscore <= score)
        {
            bestscore = score +10;
            PlayerPrefs.SetInt("HighScore", bestscore);
        }
        bestscoreText.text = "Best: " + bestscore;
        
    }

    public void HideTitle()
    {
        titleScreen.SetActive(false);
        score = 0;
        scoreText.text = "Score: 0" ;

    }

}
