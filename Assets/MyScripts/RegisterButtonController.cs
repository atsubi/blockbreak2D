using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterButtonController : MonoBehaviour
{
    GameObject cleardirector;
    GameObject yournameinfo;
    GameObject yourname;
    GameObject retrybutton;

    public void OnClick()
    {
        // データ保存
        this.cleardirector.GetComponent<ClearDirector>().SaveRankData();

        // 保存されたランキングデータ読み込み
        this.cleardirector.GetComponent<ClearDirector>().LoadRankData();

        // ランキング表示
        this.cleardirector.GetComponent<ClearDirector>().DisplayRank();

        // 名前入力欄、登録ボタン非表示、リトライボタン表示
        this.yournameinfo.SetActive(false);
        this.yourname.SetActive(false);
        gameObject.SetActive(false);
        this.retrybutton.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.cleardirector = GameObject.Find("ClearDirector");
        this.yournameinfo = GameObject.Find("yournameinfo");
        this.yourname = GameObject.Find("yourname");
        this.retrybutton = GameObject.Find("RetryButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
