using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTurn : MonoBehaviour
{
    private FishFriendRadar fishRadar;
    private Rigidbody rb;

    public float turnSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        fishRadar = GetComponent<FishFriendRadar>();
    }

    private Vector3 CalcuateDirection(List<GameObject> otherBoids)
    {
        if (otherBoids.Count == 0)
        {
            return Vector3.zero;
        }
            var directionAwayVector = new Vector3();
            foreach (GameObject Boid in otherBoids)
            {
                directionAwayVector -= (transform.position - Boid.transform.position).normalized;
            }
            directionAwayVector /= otherBoids.Count;
            return directionAwayVector;
    }
    
    private void FixedUpdate()
    {
        var dirForce = CalcuateDirection(fishRadar.FindNewEnemies());
        //var dirForceTemp = CalcuateDirection(neighbours.FindNewEnemies());
        //var dirForce2 = new Vector3(0,0,dirForceTemp.x + dirForceTemp.y);
        rb.AddForce(dirForce * turnSpeed , ForceMode.Force);
        //Debug.Log(dirForce2 * enemyMoveForce);
        
        //rb.AddRelativeTorque(dirForce2 * enemyMoveForce, ForceMode.Force);
            
    }
}
