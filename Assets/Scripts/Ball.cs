using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float ballSpd;

    // Start is called before the first frame update
    void Start()
    {
        ballSpd = 300f;

        Vector3 force = -Vector3.left * ballSpd * Time.deltaTime;
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.AddForce(force, ForceMode.Impulse);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Right Goal" || other.gameObject.name == "Left Goal")
        {
            Debug.Log(this.gameObject.name + " reached a goal");
            Destroy(this.gameObject);
        }
    }
}
