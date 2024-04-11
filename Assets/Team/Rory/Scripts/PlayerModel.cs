using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    private float currentSpeed;

    public bool onLand;
    public bool playerControlled;
    public bool interactingOn;
    public bool playerActionEnabled;
    public float fallingAirMaxSpeed;

    public float waterSpeed;
    public float landSpeed;

    [SerializeField] private PlayerStats playerStats;

    private bool facingForward;
    public GameObject netObject;
    public GameObject tempView;
    public GameObject hitBox;

    public GameObject PlayerGameObject;
    private InteractTextPopup playerInteractPopup;
    public Animator playerAnimator;
    private void Awake()
    {
        if (EventBus.Current != null)
        {
            if (EventBus.Current.ReturnMainSceneBool())
            {
                gameObject.transform.position = EventBus.Current.ReturnOldLocation();
            }
            
        }
    }

    private void Start()
    {
        interactingOn = EventBus.Current.ReturnInteracting();
        playerControlled = EventBus.Current.ReturnPlayerControl();
        EventBus.Current.IAmThePlayer(PlayerGameObject);
        playerStats = gameObject.GetComponent<PlayerStats>();
        playerInteractPopup = GetComponent<InteractTextPopup>();
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
        if (currentDirection.x < 0)
        {
            playerAnimator.transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (currentDirection.x > 0)
        {
            playerAnimator.transform.GetComponent<SpriteRenderer>().flipX = false;
        }
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
                if (facingForward)
                {
                    tempView.transform.rotation = Quaternion.FromToRotation(Vector3.right, currentDirection);
                }
                else
                {
                    tempView.transform.rotation = Quaternion.FromToRotation(Vector3.right, -currentDirection);
                }
                hitBox.transform.rotation = Quaternion.FromToRotation(Vector3.right, currentDirection);
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
            var weightSpeed = playerStats.ReturnWeightSpeedMultiplier();
            Debug.Log(weightSpeed);
            currentSpeed = maxSpeed * weightSpeed;
            rb.velocity = currentDirection * currentSpeed;
            if (currentDirection.z == Vector3.left.z)
            {
                facingForward = false;
            }
            if (currentDirection.z == Vector3.right.z)
            {
                facingForward = true;
            }
        }
        else
        {
            rb.velocity = new Vector3(currentDirection.x * maxSpeed, rb.velocity.y,0);
            playerAnimator.SetFloat("Speed", Mathf.Abs(currentDirection.x));
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
            //playerInteractPopup.RemoveText();
        }
    }

    
    public void Action()
    {
        if (playerActionEnabled)
        {
            //Debug.Log("ACTION ACTIVATE");
            var fish = netObject.transform.GetComponent<NetController>().CatchFish();
            if (fish == null) return;
            FishStatus fishStatus = fish.GetComponent<FishController>().ReturnFishStats();
            PlayerInventory.Current.AddFishToInventory(fishStatus);
            
        }
    }
}
