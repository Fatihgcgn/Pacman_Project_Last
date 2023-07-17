using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    UIScript uiScript = new UIScript();
    GameManager gameManager = new GameManager();
    private string username;
    private int _highscore;
    private int ikinci;
    private int ucuncu;
    private int dorduncu;
    private int besinci;
    private int _lowestHigh;
    private bool _scoresRead;
    private bool _isTableFound;

    Dictionary<String, int> YuksekSkor = new Dictionary<String, int>();


    public TMP_Text _firstP;
    public TMP_Text _secondP;
    public TMP_Text _thirdP;
    public TMP_Text _fourthP;
    public TMP_Text _fifthP;

    public TMP_Text _firstN;
    public TMP_Text _secondN;
    public TMP_Text _thirdN;
    public TMP_Text _fourthN;
    public TMP_Text _fifthN;

    public TMP_Text _userP;
    public TMP_Text _usern;

    public void Awake()
    {

    }
    void Start()
    {

        AddToDic();

        /*_firstP.text = YuksekSkor["Fatih"].ToString();
        _secondP.text = YuksekSkor["Gezgin"].ToString();
        _thirdP.text = YuksekSkor["Robin"].ToString();
        _fourthP.text = YuksekSkor["Chopper"].ToString();
        _fifthP.text = YuksekSkor["Zoro"].ToString();
        _userP.text = YuksekSkor["You"].ToString();

        _firstN.text = "Fatih";
        _secondN.text = "Gezgin";
        _thirdN.text = "Robin";
        _fourthN.text = "Chopper";
        _fifthN.text = "Zoro";
        _usern.text = "YOU";*/

        Debug.Log("tabloyu sıraladık.");

    }

    void Update()
    {
        ScoreYerlestir();
        _firstP.text = PlayerPrefs.GetInt("_highscore").ToString();
        _secondP.text = YuksekSkor["Fatih"].ToString();
        _thirdP.text = YuksekSkor["Gezgin"].ToString();
        _fourthP.text = YuksekSkor["Robin"].ToString();
        _fifthP.text = YuksekSkor["Chopper"].ToString();
        _userP.text = YuksekSkor["Zoro"].ToString();

        _firstN.text = "You";
        _secondN.text = "Fatih";
        _thirdN.text = "Gezgin";
        _fourthN.text = "Robin";
        _fifthN.text = "Chopper";
        _usern.text = "Zoro";

    }
    private void AddToDic()
    {
        YuksekSkor.Add("Fatih", 1000);
        YuksekSkor.Add("Gezgin", 800);
        YuksekSkor.Add("Robin", 600);
        YuksekSkor.Add("Chopper", 400);
        YuksekSkor.Add("Zoro", 300);
        YuksekSkor.Add("You", 0);
        Debug.Log("dictionary");
    }
    public class Score
    {
        public string name { get; set; }
        public int score { get; set; }

        public Score(string n, int s)
        {
            name = n;
            score = s;
        }

        public Score(string n, string s)
        {
            name = n;
            score = Int32.Parse(s);
        }
    }

    public void ScoreYerlestir()
    {
        YuksekSkor["You"] = GameManager.score;
        //Debug.Log(YuksekSkor["You"]);

        /*if (YuksekSkor["Fatih"] >= YuksekSkor["Gezgin"] && YuksekSkor["Fatih"] >= YuksekSkor["Robin"]
            && YuksekSkor["Fatih"] >= YuksekSkor["Chopper"] && YuksekSkor["Fatih"] >= YuksekSkor["Zoro"]
            && YuksekSkor["Fatih"] >= YuksekSkor["You"])
        {
            PlayerPrefs.SetInt("_highscore", YuksekSkor["Fatih"]);
            _firstN.text = "Fatih";
            ikinci = (YuksekSkor["Gezgin"]);
            _secondN.text = "Gezgin";
            ucuncu = (YuksekSkor["Robin"]);
            _thirdN.text = "Robin";
            dorduncu = (YuksekSkor["Chopper"]);
            _fourthN.text = "Chopper";
            besinci = (YuksekSkor["Zoro"]);
            _fifthN.text = "Zoro";
            _lowestHigh = (YuksekSkor["You"]);
            _usern.text = "YOU";         

            Debug.Log("1 calisti");
        }*/

        if (YuksekSkor["You"] >= PlayerPrefs.GetInt("_highscore"))
        {
            PlayerPrefs.SetInt("_highscore", YuksekSkor["You"]);


            ikinci = (YuksekSkor["Fatih"]);

            ucuncu = (YuksekSkor["Gezgin"]);

            dorduncu = (YuksekSkor["Robin"]);

            besinci = (YuksekSkor["Chopper"]);

            _lowestHigh = (YuksekSkor["Zoro"]);


            Debug.Log("Yuksek skor yapildi");

        }

        else if (YuksekSkor["You"] >= YuksekSkor["Gezgin"] && YuksekSkor["You"] < YuksekSkor["Fatih"])
        {
            PlayerPrefs.SetInt("_highscore", YuksekSkor["Fatih"]);

            ikinci = (YuksekSkor["You"]);

            ucuncu = (YuksekSkor["Gezgin"]);

            dorduncu = (YuksekSkor["Robin"]);

            besinci = (YuksekSkor["Chopper"]);

            _lowestHigh = (YuksekSkor["Zoro"]);
        }

        else if (YuksekSkor["You"] >= YuksekSkor["Robin"] && YuksekSkor["You"] < YuksekSkor["Gezgin"])
        {
            PlayerPrefs.SetInt("_highscore", YuksekSkor["Fatih"]);

            ikinci = (YuksekSkor["Gezgin"]);

            ucuncu = (YuksekSkor["You"]);

            dorduncu = (YuksekSkor["Robin"]);

            besinci = (YuksekSkor["Chopper"]);

            _lowestHigh = (YuksekSkor["Zoro"]);
        }

        else if (YuksekSkor["You"] >= YuksekSkor["Chopper"] && YuksekSkor["You"] < YuksekSkor["Robin"])
        {
            PlayerPrefs.SetInt("_highscore", YuksekSkor["Fatih"]);

            ikinci = (YuksekSkor["Gezgin"]);

            ucuncu = (YuksekSkor["Robin"]);

            dorduncu = (YuksekSkor["You"]);

            besinci = (YuksekSkor["Chopper"]);

            _lowestHigh = (YuksekSkor["Zoro"]);
        }

        else if (YuksekSkor["You"] >= YuksekSkor["Zoro"] && YuksekSkor["You"] < YuksekSkor["Chopper"])
        {
            PlayerPrefs.SetInt("_highscore", YuksekSkor["Fatih"]);

            ikinci = (YuksekSkor["Gezgin"]);

            ucuncu = (YuksekSkor["Robin"]);

            dorduncu = (YuksekSkor["Chopper"]);

            besinci = (YuksekSkor["You"]);

            _lowestHigh = (YuksekSkor["Zoro"]);
        }

        /*else if (YuksekSkor["You"] < YuksekSkor["Zoro"])
        {
            PlayerPrefs.SetInt("_highscore", YuksekSkor["Fatih"]);
            ikinci = (YuksekSkor["Gezgin"]);
            ucuncu = (YuksekSkor["Robin"]);
            dorduncu = (YuksekSkor["Chopper"]);
            besinci = (YuksekSkor["Zoro"]);
            _lowestHigh = (YuksekSkor["You"]);
            Debug.Log("son calisti");

        }*/
    }

    List<Score> scoreList = new List<Score>(10);

    /*    public void PlaceSwap(TMP_Text j, TMP_Text k)
        {
            TMP_Text m;
            m = j;
            j = k;
            k = m;
        }
    */
    void OnLevelWasLoaded(int level)
    {

        if (level == 2) StartCoroutine("UpdateGUIText");    // if scores is loaded
        //if (level == 1) _lowestHigh = _highscore = 1000;
        if (level == 1) StartCoroutine("GetHighestScore");  // if game is loaded
    }

    IEnumerator GetHighestScore()
    {
        Debug.Log("GETTING HIGHEST SCORE");

        // wait until scores are pulled from database
        float timeOut = Time.time + 4;
        while (!_scoresRead)
        {
            yield return new WaitForSeconds(0.01f);
            if (Time.time > timeOut)
            {
                Debug.Log("Timed out");
                //scoreList.Clear();
                //scoreList.Add(new Score("GetHighestScore:: DATABASE CONNECTION TIMED OUT", -1));
                break;
            }
        }

        //en yuksek scoru cekicegi kisim burası buraya list<> içerisinden en yuksek cekilecek

        /*PlayerPrefs.SetInt("_highscore", YuksekSkor["Fatih"]);
        PlayerPrefs.SetInt("second_highscore", YuksekSkor["Gezgin"]);
        PlayerPrefs.SetInt("third_highscore", YuksekSkor["Robin"]);
        PlayerPrefs.SetInt("fourth_highscore", YuksekSkor["Chopper"]);
        PlayerPrefs.SetInt("fifth_highscore", YuksekSkor["Zoro"]);
        PlayerPrefs.SetInt("_lowestHigh", YuksekSkor["You"]);*/

        High();
    }


    IEnumerator UpdateGUIText()
    {
        //LISTE BURADA GUNCELLENECEK
        


        /*
          else if (YuksekSkor["Gezgin"] >= YuksekSkor["Fatih"] && YuksekSkor["Gezgin"] >= YuksekSkor["Robin"]
            && YuksekSkor["Gezgin"] >= YuksekSkor["Chopper"] && YuksekSkor["Gezgin"] >= YuksekSkor["Zoro"]
            && YuksekSkor["Gezgin"] >= YuksekSkor["You"])
        {
            _highscore = YuksekSkor["Gezgin"];
        }

        else if (YuksekSkor["Robin"] >= YuksekSkor["Fatih"] && YuksekSkor["Robin"] >= YuksekSkor["Gezgin"]
            && YuksekSkor["Robin"] >= YuksekSkor["Chopper"] && YuksekSkor["Robin"] >= YuksekSkor["Zoro"]
            && YuksekSkor["Robin"] >= YuksekSkor["You"])
        {
            _highscore = YuksekSkor["Robin"];
        }


        else if (YuksekSkor["Chopper"] >= YuksekSkor["Fatih"] && YuksekSkor["Chopper"] >= YuksekSkor["Gezgin"]
            && YuksekSkor["Chopper"] >= YuksekSkor["Robin"] && YuksekSkor["Chopper"] >= YuksekSkor["Zoro"]
            && YuksekSkor["Chopper"] >= YuksekSkor["You"])
        {
            _highscore = YuksekSkor["Chopper"];
        }


        else if (YuksekSkor["Zoro"] >= YuksekSkor["Fatih"] && YuksekSkor["Zoro"] >= YuksekSkor["Gezgin"]
            && YuksekSkor["Zoro"] >= YuksekSkor["Robin"] && YuksekSkor["Zoro"] >= YuksekSkor["Chopper"]
            && YuksekSkor["Zoro"] >= YuksekSkor["You"])
        {
            _highscore = YuksekSkor["Zoro"];
        }
        */

        /*
        // wait until scores are pulled from database
        float timeOut = Time.time + 4;
        while (!_scoresRead)
        {
            yield return new WaitForSeconds(0.01f);
            if (Time.time > timeOut)
            {   
                //Debug.Log("TIMEOUT!");
                scoreList.Clear();
                scoreList.Add(new Score("DATABASE TEMPORARILY UNAVAILABLE", 999999));
                break;
            }
        }
        */
        //scoreList.Clear();
        //scoreList.Add(new Score("DATABASE TEMPORARILY UNAVAILABLE", 999999));                          ///////////////////////////

        //GameObject.FindGameObjectWithTag("ScoresText").GetComponent<Scores>().UpdateGUIText(scoreList);

        yield return new WaitForSeconds(0f);
    }

    /*IEnumerator ReadScoresFromDB()                                  //database den veri cekme liste burada oluscak
    {
        WWW GetScoresAttempt = new WWW(TopScoresURL);
        yield return GetScoresAttempt;

        if (GetScoresAttempt.error != null)
        {
            Debug.Log(string.Format("ERROR GETTING SCORES: {0}", GetScoresAttempt.error));
            scoreList.Add(new Score(GetScoresAttempt.error, 1234));
            StartCoroutine(UpdateGUIText());
        }
        else
        {
            // ATTENTION: assumes query will find table

            string[] textlist = GetScoresAttempt.text.Split(new string[] { "\n", "\t" },
                StringSplitOptions.RemoveEmptyEntries);

            if (textlist.Length == 1)
            {
                //`Debug.Log("== 1");
                scoreList.Clear();
                scoreList.Add(new Score(textlist[0], -123));
                yield return null;
            }
            else
            {

                string[] Names = new string[Mathf.FloorToInt(textlist.Length/2)];
                string[] Scores = new string[Names.Length];

                //Debug.Log("Textlist length: " + textlist.Length + " DATA: " + textlist[0]);
                for (int i = 0; i < textlist.Length; i++)
                {
                    if (i%2 == 0)
                    {
                        Names[Mathf.FloorToInt(i/2)] = textlist[i];
                    }
                    else Scores[Mathf.FloorToInt(i/2)] = textlist[i];
                }

                for (int i = 0; i < Names.Length; i++)
                {
                    scoreList.Add(new Score(Names[i], Scores[i]));
                }

                _scoresRead = true;
            }
        }

    }
    */
    public int High()
    {
        return PlayerPrefs.GetInt("_highscore");
    }

    public int LowestHigh()
    {
        _lowestHigh = YuksekSkor["Zoro"];
        return _lowestHigh;
    }

    
}


//DICTIONARY VE SORT KULLANARAK KARSILASTIRMA YAPARAK PUANLAMA SISTEMI YAPICAZ FATIH