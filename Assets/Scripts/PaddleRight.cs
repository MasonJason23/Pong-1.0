using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PaddleRight : MonoBehaviour
{
    private Ball ball;
    public float movementSpd = 80;

    private void Start()
    {
        ball = GameObject.FindWithTag("Ball").GetComponent<Ball>();
    }

    private void Update()
    {
        if (!ball)
        {
            ball = GameObject.FindWithTag("Ball").GetComponent<Ball>();
        }
    }

    private void FixedUpdate()
    {
        float movementAxis = Input.GetAxis("HorizontalR");
        
        Vector3 force = -Vector3.forward * movementSpd * movementAxis * Time.deltaTime;

        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.AddForce(force, ForceMode.VelocityChange);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ReflectBall();
        }
    }

    private void ReflectBall()
    {
        float angle = 30f;
        float positionZ = Mathf.Ceil(transform.position.z * 10f);
        // Debug.Log("Paddle position:" + positionZ);

        if (positionZ > 0)
        {
            angle *= -1;
        }
        angle += positionZ * 2.5f;
        Vector3 rotateVec = Quaternion.Euler(0f, angle, 0f) * Vector3.left;
        Vector3 reflect = rotateVec * 10f;

        Rigidbody rBall = ball.GetComponent<Rigidbody>();
        rBall.AddForce(reflect, ForceMode.VelocityChange);
    }
}
