using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rory
{
    public class RoridsAlignment : MonoBehaviour
    {
        private RoridsNeighbourDetection neighbours;
        public float force = 0.2f;

        private void Start()
        {
            neighbours = GetComponent<RoridsNeighbourDetection>();
        }

        private void FixedUpdate()
        {
            var newNeighbours = (neighbours.FindNewNeighbours());
            Vector3 targetDirection = CalculateMove(newNeighbours);

            Vector3 cross = Vector3.Cross(transform.forward, targetDirection);
            
            GetComponent<Rigidbody>().AddTorque(cross * force);
        }

        public Vector3 CalculateMove(List<GameObject> neighbours)
        {
            if (neighbours.Count <= 0)
            {
                return Vector3.zero;
            }

            Vector3 alignmentMove = Vector3.zero;
            foreach (var gameObject in neighbours)
            {
                alignmentMove += gameObject.transform.forward;
            }

            alignmentMove /= neighbours.Count;
            
            return alignmentMove;
        }
    }
}
