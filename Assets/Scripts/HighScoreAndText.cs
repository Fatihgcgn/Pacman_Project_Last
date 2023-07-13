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
    public int H_score;
    public ScoreManager scoreManager;
    void Start()
    {
        _score = 0;
        H_score = scoreManager.High();
    }

    void Update()
    {
        _score = GameManager.score;
        _scoreText.text = _score.ToString();
        PlayerPrefs.SetInt("_highScore", H_score);

        if (_score > PlayerPrefs.GetInt("_highScore"))   //highscore olursa ekranda çiksin
        {
            PlayerPrefs.SetInt("_highScore", _score);
            H_score = PlayerPrefs.GetInt("_highScore");
            scorePanel.SetActive(true);
        }

        
    }
}