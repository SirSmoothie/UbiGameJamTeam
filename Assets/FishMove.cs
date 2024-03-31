using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float turnSpeed;
    private FishVision fishV;
    private FishAvoid fishA;
    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        fishV = gameObject.GetComponent<FishVision>();
        fishA = gameObject.GetComponent<FishAvoid>();
    }

    public void FixedUpdate()
    {
        if (fishV.IsForwardBlocked())
        {
            if (fishV.DistanceToObstical() >= 0.2f)
            {
                rb.AddRelativeForce((Vector3.right * speed) * fishV.DistanceToObstical());
            }
        }
        else
        {
            rb.AddRelativeForce(Vector3.right * speed);
        }
        
    }
    
    
}
