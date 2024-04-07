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

    private void Awake()
    {
        if (EventBus.Current != null)
        {
            if (EventBus.Current.ReturnMainSceneBool())
            {
                gameObject.transform.position = EventBus.Current.ReturnOldLocation();
            }

            interactingOn = EventBus.Current.ReturnInteracting();
            playerControlled = EventBus.Current.ReturnPlayerControl();
        }
    }

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
        //currentDirection = (currentDirection * speed);
        if (!onLand)
        {
            rb.velocity = currentDirection * maxSpeed;
        }
        else
        {
            rb.velocity = new Vector3(currentDirection.x * maxSpeed, rb.velocity.y,0);
        }
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
            if (CurrentTrigger == null) return;
            IInteractable Object = CurrentTrigger.transform.GetComponent<IInteractable>();
            Object.Interacted(gameObject);
        }
    }
}
