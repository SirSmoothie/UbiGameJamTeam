using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rory
{

    public class RoridsNeighbourDetection : MonoBehaviour
    {
        public float dectectionRange = 5;
        public List<GameObject> neighboursInRange;
        public LayerMask detectionLayer;

        public List<GameObject> FindNewNeighbours()
        {
            neighboursInRange.Clear();

            Collider[] colliders = Physics.OverlapSphere(transform.position, dectectionRange, detectionLayer);
            
            foreach (var VARIABLE in colliders)
            {
                GameObject boid = VARIABLE.gameObject;
                if (boid != gameObject)
                {
                    RaycastHit hit;
                    Vector3 dir = boid.transform.position - transform.position;

                    if (Physics.Raycast(transform.position, dir, out hit, dectectionRange, detectionLayer))
                    {
                        if (hit.collider.gameObject == boid)
                        {
                            neighboursInRange.Add(boid);
                        }
                    }
                }
            }

            return neighboursInRange;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, dectectionRange);
        }
    }
}
