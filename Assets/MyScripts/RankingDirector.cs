using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingDirector : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        // 保存されたランキングデータ読み込み
        // 1st
        this.rankname1  = GameObject.Find("rankname1");
        this.score1 = GameObject.Find("score1");
        this.rankname1.GetComponent<Text>().text =
            PlayerPrefs.GetString("RANKNAME1", "ATSUNYAN");
        this.score1.GetComponent<Text>().text =
            PlayerPrefs.GetInt("SCORE1", 250).ToString();

        // 2nd
        this.rankname2  = GameObject.Find("rankname2");
        this.score2 = GameObject.Find("score2");
        this.rankname2.GetComponent<Text>().text =
            PlayerPrefs.GetString("RANKNAME2", "HITONYAN");
        this.score2.GetComponent<Text>().text =
            PlayerPrefs.GetInt("SCORE2", 245).ToString();

        // 3rd
        this.rankname3  = GameObject.Find("rankname3");
        this.score3 = GameObject.Find("score3");
        this.rankname3.GetComponent<Text>().text =
            PlayerPrefs.GetString("RANKNAME3", "NOANYAN");
        this.score3.GetComponent<Text>().text =
            PlayerPrefs.GetInt("SCORE3", 240).ToString();

        // 4th
        this.rankname4  = GameObject.Find("rankname4");
        this.score4 = GameObject.Find("score4");
        this.rankname4.GetComponent<Text>().text =
            PlayerPrefs.GetString("RANKNAME4", "POPKO");
        this.score4.GetComponent<Text>().text =
            PlayerPrefs.GetInt("SCORE4", 235).ToString();

        // 5th
        this.rankname5  = GameObject.Find("rankname5");
        this.score5 = GameObject.Find("score5");
        this.rankname5.GetComponent<Text>().text =
            PlayerPrefs.GetString("RANKNAME5", "PIPIMI");
        this.score5.GetComponent<Text>().text =
            PlayerPrefs.GetInt("SCORE5", 230).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
