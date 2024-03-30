using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace rory
{

    public class RoridsAvoidance : MonoBehaviour
    {
        private RoridsVision vision;
        private RaycastHit hit;
        private RoridsForward forward;
        private Rigidbody rb;

        public float SteerAngle = 1;
        public float speed = 1;
        public float turnStrength = 5;
        private void Start()
        {
            vision = GetComponent<RoridsVision>();
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            
            if (vision.Obstructed())
            {
                var turnAngle = vision.GetObstructedSight()/turnStrength;
                var tempSpeed = (vision.GetDist()/speed);
                rb.AddRelativeTorque(new Vector3(0,turnAngle * tempSpeed,0), ForceMode.Force);
            }
        }
    }

}