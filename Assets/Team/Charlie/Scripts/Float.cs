using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float floatHeight = 1f;
    public float buoyancy = 1f;
    public float waterDrag = 0.5f;
    public LayerMask waterLayer;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, floatHeight * 2, waterLayer))
        {
            float depth = floatHeight - hit.distance;
            float buoyancyForce = buoyancy * depth;
            rb.AddForce(Vector3.up * buoyancyForce);


            rb.drag = waterDrag;
        }
        else
        {
            rb.drag = 0f;
            rb.AddForce(Vector3.up * (buoyancy * floatHeight));
        }
    }
}