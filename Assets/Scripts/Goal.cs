using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            GameObject instance = Instantiate(ballPrefab);
            instance.transform.position = spawnPoint.transform.position;
        }
    }
}
