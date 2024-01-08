using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
	public float speed = 1.5f;
	public float limit = 75f; 

    // Update is called once per frame
    void Update()
    {
		float angle = limit * Mathf.Sin(Time.time * speed);
		transform.localRotation = Quaternion.Euler(0, 0, angle);
	}
}
