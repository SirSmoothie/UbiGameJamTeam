using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WanderLeftToRight : MonoBehaviour
{
    public Rigidbody rb;
    public float wanderRate = 5f;

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


        rb.AddRelativeTorque(noiseValue * wanderRate, 0f, 0f);
    }
}