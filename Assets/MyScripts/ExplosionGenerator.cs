using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGenerator : MonoBehaviour
{
    public GameObject explosionPrefab;

    public void Explosion(Vector3 position)
    {
        GameObject explosion = Instantiate(explosionPrefab) as GameObject;
        explosion.transform.position = position;
        explosion.GetComponent<ParticleSystem>().Play();
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
