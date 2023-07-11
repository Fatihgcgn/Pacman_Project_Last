using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScore : MonoBehaviour
{
    public TMP_Text _scoreText;
    public int _score;
    void Start()
    {
        _score = 0;
    }

    void Update()
    {
        _scoreText.text = _score.ToString();

        if (_score > PlayerPrefs.GetInt("_highScore"))
        {
            PlayerPrefs.SetInt("_highScore", _score);
        }
    }
}
