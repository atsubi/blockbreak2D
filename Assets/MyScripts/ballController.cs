using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballController : MonoBehaviour
{
    float ballPower = 200.0f;
    public AudioClip collisionSE;
    public AudioClip boundSE;
    public AudioClip dropSE; 
    AudioSource aud;

    void OnCollisionEnter2D(Collision2D col) 
    {
        // 音再生
        if ( col.gameObject.CompareTag("atuunyan") ) {
            this.aud.PlayOneShot(this.collisionSE);
        } else if ( col.gameObject.CompareTag("bar")
            || col.gameObject.CompareTag("kabe") ) {
            this.aud.PlayOneShot(this.boundSE);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initPower();
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ボールが画面の外に出たら初期位置に戻す
        // 残玉も減らし、玉が無い場合はゲームオーバー
        if ( transform.position.y < -6 ) {

            // 音再生
            this.aud.PlayOneShot(this.dropSE);

            // 残玉0ならゲームオーバー
            // 残玉を減らす
            if ( GameDirector.stockdata == 0 ) {
                SceneManager.LoadScene("GameOverScene");
            } else {
                GameDirector.stockdata--;
            }

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
