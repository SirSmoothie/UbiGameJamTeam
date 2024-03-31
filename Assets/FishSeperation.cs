using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSeperation : MonoBehaviour
{
    private FishFriendRadar neighbours;
    private Rigidbody rb;

    private Vector3 thing;

    public float force = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        neighbours = GetComponent<FishFriendRadar>();
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
            directionAwayVector += (transform.position - Boid.transform.position).normalized;
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
