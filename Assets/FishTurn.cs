using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTurn : MonoBehaviour
{
    private FishFriendRadar fishRadar;
    private Rigidbody rb;

    public float turnSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        fishRadar = GetComponent<FishFriendRadar>();
    }

    private void Update()
    {
        if (fishRadar.FindEnemies())
        {
            var ObjectList = fishRadar.FindNewEnemies();
            var directionAwayVector = new Vector3();
            foreach (GameObject Boid in ObjectList)
            {
                directionAwayVector += (transform.position - Boid.transform.position).normalized;
            }
            directionAwayVector /= ObjectList.Count;

            float angle = Vector3.SignedAngle(transform.right, directionAwayVector, Vector3.forward);
                
            rb.AddRelativeTorque(0, 0, angle*turnSpeed, ForceMode.Force);
        }
    }
}
