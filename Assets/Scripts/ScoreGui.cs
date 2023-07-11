using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGui : MonoBehaviour
{
    public TMPro.TextMeshPro _highScoreText;
    void Start()
    {
        _highScoreText.text = PlayerPrefs.GetInt("_highScoreText").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
