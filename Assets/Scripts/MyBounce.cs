using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBounce : MonoBehaviour
{
    public float force = 25f;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = (transform.position - other.transform.position).normalized;
            //Eliminate vertical forces
            dir.y = 0;
            rb.AddForce(-dir * force, ForceMode.Impulse);
        }
    }
}
