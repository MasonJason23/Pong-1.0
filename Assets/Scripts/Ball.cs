using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioClip audioClip;
    
    private Vector3 currentSpeed;
    private float ballSpd = 200f;

    // Start is called before the first frame update
    private void Start()
    {
        Vector3 force = Vector3.left * ballSpd * Time.deltaTime;
        if (ScoringSystem.playerOneScored)
        {
            force *= -1;
        }
        
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.AddForce(force, ForceMode.Impulse);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            playAudio();
        }
    }

    private void OnTriggerEnter(Collider other)
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

        if (other.gameObject.CompareTag("Left Goal") || other.gameObject.CompareTag("Right Goal"))
        {
            Destroy(this.gameObject);
        }
    }
    
    private void playAudio()
    {
        AudioSource audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = audioClip;
        audioSrc.Play();
    }
}
