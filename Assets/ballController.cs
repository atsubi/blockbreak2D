using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    float ballPower = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        // ボールを動かす
        GetComponent<Rigidbody2D>().AddForce((transform.up + transform.right) * this.ballPower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
