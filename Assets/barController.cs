using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barController : MonoBehaviour
{
    Rigidbody2D rigid2d;
    float moveForce = 30.0f;
    float maxSpeed = 7.0f;
    float threashold = 0.2f;
    int forward;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // barの力の向きを設定
        this.forward = 0;
        if ( Input.GetKey(KeyCode.RightArrow) ) this.forward = 1;
        if ( Input.GetKey(KeyCode.LeftArrow) ) this.forward = -1;

        // スマホの傾きでも力の向きを設定
        if ( Input.acceleration.x > this.threashold ) this.forward = 1;
        if ( Input.acceleration.x < -this.threashold ) this.forward = -1;

    }

    void FixedUpdate() 
    {
        // 入力が無い場合は止まる
        if ( forward == 0 ) {
            this.rigid2d.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        
        // プレイヤーのスピードを算出
        float speed = Mathf.Abs(this.rigid2d.velocity.x);
        
        // 最高速度以下ならば、移動する
        // if ( speed < this.maxSpeed ) {
            this.rigid2d.AddForce(transform.right * forward * this.moveForce);
        // }
    }
}
