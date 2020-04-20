using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingButtonController : MonoBehaviour
{
    public void onClick()
    {
        SelectSound.aud.Play();
        SceneManager.LoadScene("RankingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
