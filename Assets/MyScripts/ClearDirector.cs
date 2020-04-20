using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearDirector : MonoBehaviour
{
    // トータルスコア
    GameObject totalscoretext;
    int totalscore;

    // プレイヤーのランク
    GameObject yourrank;
    int        yourrank_data;

    // 登録ボタン    
    GameObject retrybutton;

    // ランク情報
    GameObject rankname1;
    GameObject score1;
    GameObject rankname2;
    GameObject score2;
    GameObject rankname3;
    GameObject score3;
    GameObject rankname4;
    GameObject score4;
    GameObject rankname5;
    GameObject score5;
    string[] rankname_data;
    int[] score_data;


    public void LoadRankData()
    {
        for ( int i=0; i<5; i++ ) {
            this.rankname_data[i] = PlayerPrefs.GetString("RANKNAME" + (i+1).ToString(), "ATSUNYAN");
            this.score_data[i] = PlayerPrefs.GetInt("SCORE" + (i+1).ToString(), 250);
        }
    }

    public void SaveRankData()
    {
        // 自身の順位を上書き
        string yourname_data = GameObject.Find("yournameinputfield").GetComponent<Text>().text;
        PlayerPrefs.SetString("RANKNAME"+(this.yourrank_data+1).ToString(), yourname_data);
        PlayerPrefs.SetInt("SCORE"+(this.yourrank_data+1).ToString(), this.totalscore);

        // 自身の順位以下のランカーを一つ下げる
        int i=this.yourrank_data+1;
        while ( i<5 ) {
            PlayerPrefs.SetString("RANKNAME"+(i+1).ToString(), this.rankname_data[i-1]);
            PlayerPrefs.SetInt("SCORE"+(i+1).ToString(), this.score_data[i-1]);
            i++;
        }
        PlayerPrefs.Save();
    }

    public void DisplayRank()
    {
        // ランキング表示
        // 1st
        this.rankname1.GetComponent<Text>().text = this.rankname_data[0];
        this.score1.GetComponent<Text>().text = this.score_data[0].ToString();

        // 2nd
        this.rankname2.GetComponent<Text>().text = this.rankname_data[1];
        this.score2.GetComponent<Text>().text = this.score_data[1].ToString();

        // 3rd
        this.rankname3.GetComponent<Text>().text = this.rankname_data[2];
        this.score3.GetComponent<Text>().text = this.score_data[2].ToString();

        // 4th
        this.rankname4.GetComponent<Text>().text = this.rankname_data[3];
        this.score4.GetComponent<Text>().text = this.score_data[3].ToString();

        // 5th
        this.rankname5.GetComponent<Text>().text = this.rankname_data[4];
        this.score5.GetComponent<Text>().text = this.score_data[4].ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        // 配列プロパティ初期化
        this.rankname_data = new string[5];
        this.score_data = new int[5];

        // オブジェクト取得
        // 1st
        this.rankname1  = GameObject.Find("rankname1");
        this.score1 = GameObject.Find("score1");

        // 2nd
        this.rankname2  = GameObject.Find("rankname2");
        this.score2 = GameObject.Find("score2");

        // 3rd
        this.rankname3  = GameObject.Find("rankname3");
        this.score3 = GameObject.Find("score3");

        // 4th
        this.rankname4  = GameObject.Find("rankname4");
        this.score4 = GameObject.Find("score4");

        // 5th
        this.rankname5  = GameObject.Find("rankname5");
        this.score5 = GameObject.Find("score5");

        // 保存されたランキングデータ読み込み
        LoadRankData();
    
        // スコア表示
        this.totalscoretext = GameObject.Find("totalscore");
        this.totalscore = GameDirector.scoredata 
            + GameDirector.stockdata*100
            - (int)GameDirector.passtime;
        this.totalscoretext.GetComponent<Text>().text = this.totalscore.ToString();

        //
        // ランク判断
        // もし5位以内であればランク欄、名前入力欄、Registerボタン表示
        //

        // 5位以内なら、名前を登録してもらうので、一時的にリトライボタン非表示
        // ランクも表示するので、オブジェクト取得
        if ( this.totalscore >= score_data[4] ) {
            this.retrybutton = GameObject.Find("RetryButton");
            this.retrybutton.SetActive(false);
            this.yourrank = GameObject.Find("yourrank");
        }

        // 1st
        if ( this.totalscore >= score_data[0] ) {
            this.yourrank_data = 0;
            this.totalscoretext.GetComponent<Text>().color
                = new Color(0.98f, 0.75f, 0.0f, 1.0f);
            this.yourrank.GetComponent<Text>().text
                = "1ST";
            this.yourrank.GetComponent<Text>().color
                = new Color(0.98f, 0.75f, 0.0f, 1.0f);
        // 2nd
        } else if ( this.totalscore < score_data[0]
                    && this.totalscore >= score_data[1] ) {
            this.yourrank_data = 1;
            this.totalscoretext.GetComponent<Text>().color
                = new Color(0.67f, 0.67f, 0.67f, 1.0f);
            this.yourrank.GetComponent<Text>().text
                = "2ND";
            this.yourrank.GetComponent<Text>().color
                = new Color(0.67f, 0.67f, 0.67f, 1.0f);
        // 3rd
        } else if ( this.totalscore < score_data[1]
                    && this.totalscore >= score_data[2] ) {
            this.yourrank_data = 2;
            this.totalscoretext.GetComponent<Text>().color
                = new Color(0.98f, 0.33f, 0.0f, 1.0f);
            this.yourrank.GetComponent<Text>().text
                = "3RD";
            this.yourrank.GetComponent<Text>().color
                = new Color(0.98f, 0.33f, 0.0f, 1.0f);
        // 4th
        } else if ( this.totalscore < score_data[2] 
                    && this.totalscore >= score_data[3] ) {
            this.yourrank_data = 3;
            this.totalscoretext.GetComponent<Text>().color
                = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            this.yourrank.GetComponent<Text>().text
                = "4TH";
            this.yourrank.GetComponent<Text>().color
                = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        // 5th
        } else if ( this.totalscore < score_data[3] 
                    && this.totalscore >= score_data[4] ) {
            this.yourrank_data = 4;
            this.totalscoretext.GetComponent<Text>().color
                = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            this.yourrank.GetComponent<Text>().text
                = "5TH";
            this.yourrank.GetComponent<Text>().color
                = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        // ランク外
        // ランク欄、名前入力欄、Registerボタン非表示
        } else if ( totalscore < score_data[4] ) {
            GameObject.Find("yourrankinfo").SetActive(false);
            GameObject.Find("yourrank").SetActive(false);
            GameObject.Find("yournameinfo").SetActive(false);
            GameObject.Find("yourname").SetActive(false);
            GameObject.Find("RegisterButton").SetActive(false);
        }

        // ランキング表示
        DisplayRank();

    }

    // Update is called once per frame
    void Update()
    {
                
    }
}
