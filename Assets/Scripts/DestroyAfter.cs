using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float time = 10;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);   
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Respawn")){
            Destroy(gameObject);
        }
    }
}
