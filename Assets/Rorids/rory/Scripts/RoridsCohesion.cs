using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rory
{

    public class RoridsCohesion : MonoBehaviour
    {
        private RoridsNeighbourDetection neighbours;
        private Rigidbody rb;

        public float force = 5f;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            neighbours = GetComponent<RoridsNeighbourDetection>();
        }

        public Vector3 CalcuateDirection(List<GameObject> otherBoids)
        {
            if (otherBoids.Count == 0)
            {
                return Vector3.zero;
            }
            var directionAwayVector = new Vector3(0, 0, 0);
            foreach (GameObject Boid in otherBoids)
            {
                directionAwayVector += (Boid.transform.position - transform.position).normalized;
            }
            directionAwayVector /= otherBoids.Count;
            return directionAwayVector;
        }

        private void FixedUpdate()
        {
            var dirForce = CalcuateDirection(neighbours.neighboursInRange);
            rb.AddForce(dirForce * force, ForceMode.Force);
            
        }
    }
}
