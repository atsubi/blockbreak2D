using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockController : MonoBehaviour
{
    GameObject generator;

    // Start is called before the first frame update
    void Start()
    {
        this.generator = GameObject.Find("ExplosionGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) 
    {

        // 爆発演出
        this.generator.GetComponent<ExplosionGenerator>().Explosion(
            transform.position);

        // スコア更新
        GameDirector.scoredata += 10;

        // blockの数を減らす
        GameDirector.block_num--;

        // 自身を消す
        Destroy(gameObject);
    }
}
