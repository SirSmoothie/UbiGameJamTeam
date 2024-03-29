using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEyes : MonoBehaviour
{
    public int rays = 10;
    public float maxAngle = 120f;
    public float detectionRange = 4f;
    public LayerMask detectionLayer;
    public Avoid avoidScript;

    public List<Transform> detectedObjects = new List<Transform>();

    private void Start()
    {
        avoidScript = GetComponent<Avoid>();
    }

    private void FixedUpdate()
    {
        detectedObjects.Clear();
        for (int i = -rays / 2; i <= rays / 2; i++)
        {
            float spreadAngle = -maxAngle / (rays - 1);
            
            Vector3 dir = Quaternion.Euler(0, i * spreadAngle, 0) * transform.forward;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, detectionRange, detectionLayer))
            {
                detectedObjects.Add(hit.transform);
                avoidScript.AvoidObstacle(); 
                Debug.DrawRay(transform.position, dir * hit.distance, Color.red);
            }
            else
            {
                Debug.DrawRay(transform.position, dir * detectionRange, Color.green);
            }
        }
    }
}