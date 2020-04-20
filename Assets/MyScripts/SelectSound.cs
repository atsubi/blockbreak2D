using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSound : MonoBehaviour
{
    public static AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        SelectSound.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
