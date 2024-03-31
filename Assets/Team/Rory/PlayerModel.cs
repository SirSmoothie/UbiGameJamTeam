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
    public bool dragOn;
    public float maxSpeed;
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
        currentDirection = new Vector3(currentDirection.x + desiredDirection.x, currentDirection.y + desiredDirection.y, 0);
        if (dragOn)
        {

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

    }

    private void FixedUpdate()
    {
        currentDirection = (currentDirection * speed) * accelerationSpeed;
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        rb.AddForce(currentDirection);
        //Debug.Log(rb.velocity.magnitude);
    }
}
