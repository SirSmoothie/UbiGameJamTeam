using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterTurnTowards : MonoBehaviour
{
    private Rigidbody rb;
        
    public float turnSpeed = 0.05f;
    public float smoothingRate = 1f;
    public Transform targetTransform;
    private Vector3 TurnDir;
    private bool needToAvoid;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (targetTransform != null)
        {
            if (needToAvoid)
            {
                rb.AddRelativeForce(TurnDir, ForceMode.Acceleration);
            }
            else
            {
                Vector3 targetDir;
                targetDir = targetTransform.position - transform.position;

                float angle = Vector3.SignedAngle(transform.forward, targetDir, Vector3.up);

                rb.AddRelativeTorque(angle * turnSpeed, angle * turnSpeed, 0, ForceMode.Acceleration);
                Debug.Log(targetDir);
            }
        }
    }

    public void newTurnTowardsDir(bool value, Vector3 dir)
    {
        needToAvoid = value;
        TurnDir = dir;
    }
}
