using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTowards : MonoBehaviour
{
    public Vector3 targetPosition;
    public float turnspeed = 2;
    public Transform target;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 targetDir;


        if (target != null)
        {
            targetDir = target.position - transform.position;
        }
        else
        {
            targetDir = targetPosition - transform.position;
        }


        float angle = Vector3.SignedAngle(transform.forward, targetDir, Vector3.up);

        Vector3 torque = Vector3.up * angle * turnspeed;


        rb.AddRelativeTorque(torque);
    }
}