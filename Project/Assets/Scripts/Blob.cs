using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Blob : MonoBehaviour
{

    public Sprite[] faceSprites;
    public Socket[] appendageSockets;
    public float movementInterval = 0;
    public float movementSpeed = 1;
    public float baseMovementSpeed = 1;
    public Vector2 movementBounds = Vector2.zero;
    public int socketsUsed;
    [Range(0,1)]
    public float speedScalar = 0.5f;
    
    
    private float lastMoveTime = 0;
    private Rigidbody2D _rb;
    private SpriteRenderer rend;
    private Vector2 desiredLocation = Vector2.zero;
    private int emptySocketIndex = 0;

    public int numRightLegs = 0;
    public int numLeftLegs = 0;
    public int numRightArms = 0;
    public int numLeftArms = 0;

    public int NumArms => numLeftArms + numRightArms;
    public int NumLegs => numLeftLegs + numRightLegs;
    


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Vector3.zero, movementBounds);
    }
    
    private void Start()
    {
        
        CalculateDesiredLocation();
        _rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        appendageSockets = GetComponentsInChildren<Socket>();
    }

    private void FixedUpdate()
    {
        var desiredDirection = desiredLocation - new Vector2(transform.position.x,transform.position.y);
        
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
        //desiredLocation = desiredLocation * Mathf.PerlinNoise(Time.time, Time.time);
    }

    public void Attach(Appendage appendage)
    {
        if (GetOpenSocket() != null)
        {
            var socket = GetOpenSocket();
            socket.Attach(appendage);

            int numLimbs = numLeftArms + numLeftLegs + numRightArms + numRightLegs;
            if (numLimbs < faceSprites.Length)
                rend.sprite = faceSprites[numLimbs];
            float n = 1 - numLimbs * .15f;
            rend.color = new Color(1, n, n);

            if (appendage.Type == "Arm")
            {
                if (appendage.Side == "Left") numLeftArms++;
                if (appendage.Side == "Right") numRightArms++;
            }
            if (appendage.Type == "Leg")
            {
                if (appendage.Side == "Left") numLeftLegs++;
                if (appendage.Side == "Right") numRightLegs++;
            }
        }
        
        movementSpeed = baseMovementSpeed + speedScalar * socketsUsed;

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
            socketsUsed += 1;
        }
        return null;
    }
}
