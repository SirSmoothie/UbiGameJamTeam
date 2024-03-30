using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BetterBoidAvoid : MonoBehaviour
{
    public int noOfPoints = 20;
    private float turnFraction = 0.618033988749f;
    public float size = 1;

    public GameObject Dot;

    public List<GameObject> Dots;

    
    /*
    public void CalculateNewThing()
    {
        foreach (var VARIABLE in Dots)
        {
            Destroy(VARIABLE);
        }
        Dots = new List<GameObject>();
        for (int i = 0; i < noOfPoints; i++)
        {
            float t = i / (noOfPoints - 1f);
            float inclination = Mathf.Acos(1 - 2 * t);
            float azimuth = 2 * Mathf.PI * turnFraction * i;

            float x = Mathf.Sin(inclination) * Mathf.Cos(azimuth);
            float y = Mathf.Sin(inclination) * Mathf.Sin(azimuth);
            float z = Mathf.Cos(inclination);

            CreateNewPoint(x, y, z, Color.red);
        }
    }
    */

    void CreateNewPoint(float xValue, float yValue, float zValue, Color colour)
    {
        var vector = new Vector3(xValue * size, yValue * size, zValue * size);
        var o = Instantiate(Dot, vector, quaternion.identity);
        Dots.Add(o);
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, range, obstacleMask))
        {
            BTT.newTurnTowardsDir(true,FindUnobstructedDirection());
        }
        else
        {
            BTT.newTurnTowardsDir(false,Vector3.zero);
        }
    }

    public BetterTurnTowards BTT;
    public float range;
    public float radius;
    public float viewRadius;
    public LayerMask obstacleMask;
    
    Vector3 FindUnobstructedDirection()
    {
        Vector3 bestDir = transform.forward;
        float furthestUnobstructedDst = 0;
        RaycastHit hit;

        for (int i = 0; i < BoidHelper.directions.Length; i++)
        {
            Vector3 dir = transform.TransformDirection(BoidHelper.directions[i]);
            if (Physics.Raycast(transform.position, dir, out hit, viewRadius, obstacleMask))
            {
                if (hit.distance > furthestUnobstructedDst)
                {
                    bestDir = dir;
                    furthestUnobstructedDst = hit.distance;
                }
                else
                {
                    return dir;
                }
            }
        }

        return bestDir;
    }
}
