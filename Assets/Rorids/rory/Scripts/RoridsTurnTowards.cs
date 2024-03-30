using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rory
{

    public class RoridsTurnTowards : MonoBehaviour
    {
        private Rigidbody rb;

        public bool isFlocking;
        
        public float turnSpeed = 0.05f;
        public float smoothingRate = 1f;
        public Transform targetTransform;
        

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (targetTransform != null)
            {
                Vector3 targetDir;
                targetDir = targetTransform.position - transform.position;

                float angle = Vector3.SignedAngle(transform.forward, targetDir, Vector3.up);
                
                rb.AddRelativeTorque(0, angle*turnSpeed, 0, ForceMode.Force);
            }
            
            if (targetTransform != null && isFlocking)
            {
                Vector3 targetDir;
                targetDir = targetTransform.position - (transform.position + Vector3.forward*smoothingRate);
                targetDir = (targetTransform.position+targetDir) - transform.position;
                
                
                float angle = Vector3.SignedAngle(transform.forward, targetDir, Vector3.up);
                
                rb.AddRelativeTorque(0, angle*turnSpeed, 0, ForceMode.Force);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, transform.position+transform.forward*smoothingRate);
            
            Gizmos.DrawLine(transform.position+transform.forward*smoothingRate, targetTransform.position);
            
        }
    }
}
