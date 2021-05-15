using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Blob : MonoBehaviour
{

    public Socket[] appendageSockets;
    public float movementInterval = 0;
    public float movementSpeed = 1;
    public Vector2 movementBounds = Vector2.zero;
    
    
    private float lastMoveTime = 0;
    private Rigidbody2D _rb;
    private Vector2 desiredLocation = Vector2.zero;
    private float step = 0;
    private int emptySocketIndex = 0;

    public int numRightLegs = 0;
    public int numLeftLegs = 0;
    public int numRightArms = 0;
    public int numLeftArms = 0;

    public int NumArms => numLeftArms + numRightArms;
    public int MumLegs => numLeftLegs + numRightLegs;
    


    private void Start()
    {
        
        
        _rb = GetComponent<Rigidbody2D>();
        appendageSockets = GetComponentsInChildren<Socket>();
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


    private void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {     
            
            appendageSockets[0].Attach(FindObjectOfType<Appendage>()); 
        }
    }

    private void CalculateDesiredLocation()
    {
        var boundsX = movementBounds.x / 2;
        var boundsY = movementBounds.y / 2;
        desiredLocation = new Vector2(UnityEngine.Random.Range(-boundsX,boundsX), UnityEngine.Random.Range(-boundsY,boundsY));
        desiredLocation = desiredLocation * Mathf.PerlinNoise(Time.time, Time.time);
    }

    public void Attach(Appendage appendage)
    {
        if (GetOpenSocket() != null)
        {
            var socket = GetOpenSocket();
            socket.Attach(appendage);

            if (appendage.Type == "Arm")
            {
                if (appendage.Side == "Left") numLeftArms++;
                if (appendage.Side == "Righ") numRightArms++;
            }
            if (appendage.Type == "Leg")
            {
                if (appendage.Side == "Left") numLeftLegs++;
                if (appendage.Side == "Righ") numRightLegs++;
            }
            
        }
        
    }

    /// <summary>
    /// Checks if any of the Blob's sockets are open
    /// </summary>
    /// <returns>returns the first open Socket found. If there are no open Sockets, returns null</returns>
    private Socket GetOpenSocket()
    {
        foreach (var socket in appendageSockets)
        {
            if (socket.HasAppendage == false)
            {
                return socket;
            }
        }

        return null;
    }

    
    
    
}
