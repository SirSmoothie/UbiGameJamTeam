using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    public Rigidbody rb;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * speed);
    }
}
