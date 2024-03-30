using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rory
{
    public class RoridsSteering : MonoBehaviour
    {
        private Rigidbody rb;
        private float perlinOffset;
        [SerializeField] private float perlinNoise;
        public float speed = 2f;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            perlinOffset = Random.Range(-99999, 99999);
        }

        private void FixedUpdate()
        {
            perlinNoise = Mathf.PerlinNoise1D(Time.time + perlinOffset);
            perlinNoise -= 0.5f;
            rb.AddRelativeTorque(0, perlinNoise * speed, 0);
        }

    }
}
