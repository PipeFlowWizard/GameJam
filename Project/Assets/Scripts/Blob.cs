using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{

    public Socket[] appendageSockets = new Socket[5];
    private float lastMoveTime = 0;
    public float movementInterval = 0;
    public float movementSpeed = 1;
    public Vector2 movementBounds = Vector2.zero;
    
    private Rigidbody2D _rb;
    private Vector2 desiredLocation = Vector2.zero;
    private float step = 0;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var desiredDirection = desiredLocation - new Vector2(transform.position.x,transform.position.y);
        
        step = movementSpeed * Time.time;
        if (Time.time - lastMoveTime > movementInterval)
        {
            lastMoveTime = Time.time;
            CalculateDesiredLocation();
        }

        _rb.MovePosition(new Vector2(transform.position.x,transform.position.y) + (desiredDirection * movementSpeed * Time.deltaTime));
    }

    private void CalculateDesiredLocation()
    {
        var boundsX = movementBounds.x / 2;
        var boundsY = movementBounds.y / 2;
        desiredLocation = new Vector2(UnityEngine.Random.Range(-boundsX,boundsX), UnityEngine.Random.Range(-boundsY,boundsY));
        desiredLocation = desiredLocation * Mathf.PerlinNoise(Time.time, Time.time);
    }
}
