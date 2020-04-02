using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    GameObject infoarea;
    
    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトを画面サイズに合わせる
        FillScreen();

        // ゲーム情報エリアを画面の横サイズに合わせて配置
        this.infoarea = GameObject.Find("InfoArea");
        float width = this.infoarea.GetComponent<SpriteRenderer>().bounds.size.x;
        this.infoarea.transform.localScale = new Vector3(Screen.width/width, 1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
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
