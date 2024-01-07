using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpheres : MonoBehaviour
{
    Vector3 startPos;
    Vector3 spawnPos;
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        InvokeRepeating("Spawn", 1, 0.7f);
    }

    public void Spawn(){
        spawnPos = new Vector3(Random.Range(-10, 10), 0, 0);
        transform.position = spawnPos + startPos;
        Instantiate(sphere, transform.position, Quaternion.identity);
    }
}
