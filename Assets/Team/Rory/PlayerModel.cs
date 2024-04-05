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
    private bool moving;
    public bool dragOn;
    public float maxSpeed;

    public bool onLand;
    public bool playerControlled;
    public bool interactingOn;
    public float fallingAirMaxSpeed;

    public float waterSpeed;
    public float landSpeed;
    public void PlayerControlled(bool value)
    {
        interactingOn = value;
    }
    public void PlayerControlledLimited(bool value)
    {
        playerControlled = value;
    }
    public void Horizontal(float value)
    {
        if (playerControlled)
        {
            desiredDirection.x = value;
        }
    }
    public void Vertical(float value)
    {
        if (playerControlled)
        {
            if (onLand != true)
            {
                desiredDirection.y = value;
            }
        }
    }

    void Update()
    {
        if (onLand)
        {
            rb.useGravity = true;
        }
        else
        {
            rb.useGravity = false;
        }
        currentDirection = new Vector3(desiredDirection.x, desiredDirection.y, 0);
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


    public GameObject CurrentTrigger;
    private void OnTriggerEnter(Collider other)
    {
        CurrentTrigger = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (CurrentTrigger == other.gameObject)
        {
            CurrentTrigger = null;
        }
    }

    public void Interact()
    {
        if (interactingOn)
        {
            IInteractable Object = CurrentTrigger.transform.GetComponent<IInteractable>();
            Object.Interacted();
        }
    }
}
