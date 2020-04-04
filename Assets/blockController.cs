using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        // スコア更新
        GameDirector.scoredata += 10;

        // オブジェクト破棄
        Destroy(gameObject);

    }
}
