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

    void FixedUpdate()
    {
        ballSpd += Time.deltaTime * 10f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Left Goal"))
        {
            ScoringSystem.scoreP2 += 1;
            Debug.Log("Player Two Scored!");
        }
        else if (other.gameObject.CompareTag("Right Goal"))
        {
            ScoringSystem.scoreP1 += 1;
            Debug.Log("Player One Scored!");
        }
        
        Debug.Log("Current Score: P1 - " + ScoringSystem.scoreP1 + " | P2 - " + ScoringSystem.scoreP2);
        
        if (other.gameObject.CompareTag("Left Goal") || other.gameObject.CompareTag("Right Goal"))
        {
            Destroy(this.gameObject);
        }
    }
}
