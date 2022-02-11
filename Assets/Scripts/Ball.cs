using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float ballSpd = 200f;
    private Vector3 currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 force = Vector3.left * ballSpd * Time.deltaTime;
        if (ScoringSystem.playerOneScored)
        {
            force *= -1;
        }
        
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.AddForce(force, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Left Goal"))
        {
            ScoringSystem.scoreP2 += 1;
            ScoringSystem.playerOneScored = false;
        }
        else if (other.gameObject.CompareTag("Right Goal"))
        {
            ScoringSystem.scoreP1 += 1;
            ScoringSystem.playerOneScored = true;
        }
        
        Debug.Log("Current Score: P1 - " + ScoringSystem.scoreP1 + " | P2 - " + ScoringSystem.scoreP2);
        
        if (other.gameObject.CompareTag("Left Goal") || other.gameObject.CompareTag("Right Goal"))
        {
            Destroy(this.gameObject);
        }
    }
}
