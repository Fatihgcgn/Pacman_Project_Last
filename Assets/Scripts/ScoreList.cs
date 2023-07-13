using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ScoreList : MonoBehaviour
{
    public int Fatih = 950;
    public int Gezgin = 700;
    public int Robin = 600;
    public int Chopper = 500;
    public int Zoro = 400;

    public TMP_Text _fatihp;
    public TMP_Text _gezginp;
    public TMP_Text _robinp;
    public TMP_Text _chopperp;
    public TMP_Text _zorop;

    public TMP_Text _fatihN;
    public TMP_Text _gezginN;
    public TMP_Text _robinN;
    public TMP_Text _chopperN;
    public TMP_Text _zoroN;

    public TMP_Text _userp;
    public TMP_Text _usern;
    public int userp;
    public string usern;

    public GameManager gameManager;

    public int ScoreGetir(int a)
    {
        return a;
    }

    public void PlaceSwap(TMP_Text j, TMP_Text k)
    {
        TMP_Text m;
        m = j;
        j = k;
        k = m;
    }
    void Start()
    {
        
        usern = "YOU";

        _fatihp.text = Fatih.ToString();
        _gezginp.text = Gezgin.ToString();
        _robinp.text = Robin.ToString();
        _chopperp.text = Chopper.ToString();
        _zorop.text = Zoro.ToString();
        _userp.text = userp.ToString();

        _fatihN.text = "Fatih";
        _gezginN.text = "Gezgin";
        _robinN.text = "Robin";
        _chopperN.text = "Chopper";
        _zoroN.text = "Zoro";
        _usern.text = "YOU";


    }

    // Update is called once per frame
    void Update()
    {


        userp = GameManager.score;

        if (userp >= Zoro && userp < Chopper)
        {
            PlaceSwap(_userp, _zorop);
            PlaceSwap(_usern, _zoroN);
        }
        else if (userp >= Chopper && userp < Robin)
        {
            PlaceSwap(_userp, _chopperp);
            PlaceSwap(_usern, _chopperN);
        }
        else if (userp >= Robin && userp < Gezgin)
        {
            PlaceSwap(_userp, _robinp);
            PlaceSwap(_usern, _robinN);
        }
        else if (userp >= Gezgin && userp < Fatih)
        {
            PlaceSwap(_userp, _gezginp);
            PlaceSwap(_usern, _gezginN);
        }
        else if (userp >= Fatih)
        {
            PlaceSwap(_userp, _fatihp);
            PlaceSwap(_usern, _fatihN);
        }
    }
}
