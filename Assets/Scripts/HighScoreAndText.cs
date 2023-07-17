using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreAndText : MonoBehaviour
{
    public GameManager gameManager;

    public TMP_Text _scoreText;
    public int _score;
    public GameObject scorePanel;
    public int H_score = PlayerPrefs.GetInt("_highScore");
    public ScoreManager scoreManager;
    void Start()
    {
        _score = 0;
    }

    void Update()
    {
        _score = GameManager.score;
        _scoreText.text = _score.ToString();
        //highscore 300 den sonra hg 1000 e s?f?rlan?o

        if (_score > H_score)   //highscore olursa ekranda çiksin
        {
            PlayerPrefs.SetInt("_highScore", _score);
            scorePanel.SetActive(true);
            H_score = PlayerPrefs.GetInt("_highScore");
        }

        
    }
}