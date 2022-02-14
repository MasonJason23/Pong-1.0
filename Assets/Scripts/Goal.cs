using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public ParticleSystem particleScore;
    public GameObject goalSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            AudioSource audioSrc = goalSound.GetComponent<AudioSource>();
            audioSrc.Play();
            
            particleScore.Play();
            GameObject instance = Instantiate(ballPrefab);
            instance.transform.position = spawnPoint.transform.position;
        }
    }
}
