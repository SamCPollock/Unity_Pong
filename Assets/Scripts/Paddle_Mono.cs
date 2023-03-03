using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Mono : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;

    [SerializeField] private float screenBounds;

    void Start()
    {
        
    }

    void Update()
    {
        HandleInput();   
        KeepInScreen();
    }
    
    private void HandleInput()
    {
        if (Input.GetKey(upKey))
        {
            MoveUp();
        }

        if (Input.GetKey(downKey))
        {
            MoveDown();
        }
    }

    private void MoveUp()
    {
        gameObject.transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }

    private void MoveDown()
    {
        gameObject.transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
    }

    private void KeepInScreen()
    {
        if (transform.position.y > screenBounds)
        {
            transform.position = new Vector3(transform.position.x, screenBounds, transform.position.z);
        }
        if (transform.position.y < -screenBounds)
        {
            transform.position = new Vector3(transform.position.x, -screenBounds, transform.position.z);
        }
    }
}
