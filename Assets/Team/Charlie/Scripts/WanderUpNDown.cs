using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderUpNDown : MonoBehaviour
{
    public Rigidbody rb;
    public float wanderRate = 5f;
    public float upwardForce = 5f;
    public float downwardForce = 2f;

    float offset;
    float minValue = -999f;
    float maxValue = 999f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = Random.Range(minValue, maxValue);
    }

    void FixedUpdate()
    {
        float noiseValue = Mathf.PerlinNoise(Time.time + offset, 0f);
        noiseValue = Mathf.Lerp(-1f, 1f, noiseValue);


        rb.AddRelativeTorque(0f, noiseValue * wanderRate, 0f);


        if (noiseValue > 0f)
        {
            rb.AddForce(transform.up * upwardForce, ForceMode.Force);
        }
        else
        {
            rb.AddForce(-transform.up * downwardForce, ForceMode.Force);
        }
    }
}