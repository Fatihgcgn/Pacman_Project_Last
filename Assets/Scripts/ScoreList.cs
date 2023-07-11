using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreList : MonoBehaviour
{
    public int Fatih123 = 59000;
    public int Gezgin = 13000;
    public int Robin = 7000;
    public int Chopper = 4000;
    public int Zoro = 1000;

    public int user;
    public GameManager gameManager;
    public int ScoreGetir(int a)
    {
        return a;
    }

    void Start()
    {
        user = 0;
    }

    // Update is called once per frame
    void Update()
    {
        user = GameManager.score;
    }
}
