using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public float speed = 1;
    public Vector2 desiredDirection;
    public Vector3 currentDirection;
    public float accelerationSpeed = 0.2f;
    public float deAccelerationRate = 0.2f;
    public float fakeDrag;
    public Rigidbody rb;
    public bool moving;
    public void Horizontal(float value)
    {
        desiredDirection.x = value;
    }
    public void Vertical(float value)
    {
        desiredDirection.y = value;
    }

    void Update()
    {
        var TempDirection = new Vector3(Mathf.Clamp(currentDirection.x + desiredDirection.x * accelerationSpeed, -1,1), Mathf.Clamp(currentDirection.y + desiredDirection.y * accelerationSpeed,-1,1), 0);
        currentDirection = TempDirection * speed;
        if (desiredDirection == Vector2.zero)
        {
            moving = false;
            currentDirection = currentDirection * deAccelerationRate;
        }
        else
        {
            moving = true;
        }

        if (moving)
        {
            rb.drag = 0f;
        }
        else
        {
            rb.drag = fakeDrag;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(currentDirection);
    }
}
