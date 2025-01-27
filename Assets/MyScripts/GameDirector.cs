﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject infoarea;
    GameObject time;
    GameObject score;
    GameObject stock;

    public static float passtime;
    public static int scoredata;
    public static int stockdata;
    public static int block_num;
    
    void Init()
    {
        GameDirector.passtime = 0;
        GameDirector.scoredata = 0;
        GameDirector.stockdata = 2;
        GameDirector.block_num = 12;
    }

    // Start is called before the first frame update
    void Start()
    {
        // ゲーム情報初期化
        Init();

        // オブジェクトを画面サイズに合わせる
        FillScreen();

        // ゲーム情報エリアを画面の横サイズに合わせて配置
        this.infoarea = GameObject.Find("InfoArea");
        float width = this.infoarea.GetComponent<SpriteRenderer>().bounds.size.x;
        this.infoarea.transform.localScale = new Vector3(Screen.width/width, 1, 1);

        // ゲームUIのtimeを読み込む
        this.time = GameObject.Find("time");

        // ゲームUIのscoreを読み込む
        this.score = GameObject.Find("score");

        // ゲームUIのstockを読み込む
        this.stock = GameObject.Find("stock");
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間更新
        GameDirector.passtime += Time.deltaTime;
        int minutes = (int)GameDirector.passtime/60;
        int seconds = (int)GameDirector.passtime%60;
        int millseconds = (int)(GameDirector.passtime*100)%100;
        this.time.GetComponent<Text>().text =
            minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + millseconds.ToString("00");

        // スコア表示
        this.score.GetComponent<Text>().text = GameDirector.scoredata.ToString("0000");

        // 残玉表示
        this.stock.GetComponent<Text>().text = GameDirector.stockdata.ToString("0");

        // blockの数が0なら、ゲームクリア
        if ( GameDirector.block_num == 0 ) {
            SceneManager.LoadScene("ClearScene");
        }

    }

    // 画面端にCollider2Dを設定するため、このオブジェクトを画面サイズにする
    private void FillScreen()
    {
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldwidth = worldHeight / Screen.height * Screen.width;
        transform.localScale = new Vector3(worldwidth, worldHeight);

        Vector3 tempPosition = Camera.main.transform.position;
        tempPosition.z = 0f;
        transform.position = tempPosition;
    }
}
