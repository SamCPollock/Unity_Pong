using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball_Mono : MonoBehaviour
{
    public Vector3 startingVelocity = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 velocity;
    public float maxSpeed;
    public float screenBoundsY = 4; 
    public float screenBoundsX = 8.5f;
    [Range(1f, 1.5f)]public float accelerationRate;

    [SerializeField] private GameManager_Mono gameManager; 

    void Start()
    {
        velocity = startingVelocity;
    }

    private void Update()
    {
        HandleBounds();
        if (velocity == Vector3.zero)
        {
            if (Input.anyKeyDown)
            {
                velocity = startingVelocity;
            }
        }
    }
    
    void FixedUpdate()
    {
        // Movement
        gameObject.transform.position += velocity;
    }

    private void HandleBounds()
    {
        if (gameObject.transform.position.y + velocity.y > screenBoundsY ||
            gameObject.transform.position.y + velocity.y < -screenBoundsY)
        {
            velocity.y = -velocity.y;
        }

        if (gameObject.transform.position.x + velocity.x > screenBoundsX)
        {
            gameManager.PointScored(true);
        }
        else if (gameObject.transform.position.x + velocity.x < -screenBoundsX)
        {
            gameManager.PointScored(false);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        gameManager.AddVolley();
        if (col.gameObject.CompareTag("Paddle"))
        {
            velocity.x = -velocity.x;
            if (Mathf.Abs(velocity.x) < maxSpeed)
            {
                 velocity.x = velocity.x * accelerationRate;
                 Debug.Log("INCREASING SPEED");
            }        
        }
    }
}
