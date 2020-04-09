using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearDirector : MonoBehaviour
{
    GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        this.score = GameObject.Find("score");
    }

    // Update is called once per frame
    void Update()
    {
        this.score.GetComponent<Text>().text = GameDirector.scoredata.ToString("0000");
    }
}
