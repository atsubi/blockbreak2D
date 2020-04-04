using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    float ballPower = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        initPower();
    }

    // Update is called once per frame
    void Update()
    {
        // ボールが画面の外に出たら初期位置に戻す
        // 残玉も減らし、玉が無い場合はゲームオーバー
        if ( transform.position.y < -6 ) {

            // 残玉を減らす
            GameDirector.stockdata--;
            
            // 初期位置に戻す
            transform.position = new Vector3(0.0f, -1.5f, 0.0f);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            initPower();
        }
    }

    void initPower()
    {
        // ボールを動かす
        GetComponent<Rigidbody2D>().AddForce((transform.up + transform.right) * this.ballPower);
    }
}
