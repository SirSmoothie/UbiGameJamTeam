using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighboursRaycast : MonoBehaviour
{
    public LayerMask detectionLayer;

    public List<GameObject> neighbours = new List<GameObject>();
    public float detectionRange = 5f;

    void FixedUpdate()
    {
        DetectNeighbours();
    }

    void DetectNeighbours()
    {
        neighbours.Clear();

        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange, detectionLayer);

        foreach (Collider collider in colliders)
        {
            GameObject detectedObject = collider.gameObject;
            if (detectedObject != gameObject)
            {
                RaycastHit hit;
                Vector3 direction = detectedObject.transform.position - transform.position;

                if (Physics.Raycast(transform.position, direction, out hit, detectionRange, detectionLayer))
                {
                    if (hit.collider.gameObject == detectedObject)
                    {
                        neighbours.Add(detectedObject);
                        
                    }
                }
            }
        }
    }
}