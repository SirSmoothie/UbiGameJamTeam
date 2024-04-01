using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAvoid : MonoBehaviour
{

    private FishVision fishV;
    private Rigidbody rb;

    public float turnSpeed;
    public float turnSpeed2;
    
    private void Start()
    {
        fishV = gameObject.GetComponent<FishVision>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (fishV.IsForwardBlocked())
        {
            var turnAngle = fishV.FindNearestNonObstucted() * (turnSpeed);
            var dist = fishV.ForwardDist();
            rb.AddRelativeTorque(new Vector3(0,0,turnAngle*dist), ForceMode.Force);
        }
    }
}
