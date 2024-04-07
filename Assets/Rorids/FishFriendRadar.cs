using System;
using System.Collections;
using System.Collections.Generic;
using rory;
using UnityEngine;

public class FishFriendRadar : MonoBehaviour
{
    public float dectectionRange = 5;
    public float personalBubbleRange = 5;
    public float enemyDectRange = 10;
    public List<GameObject> neighboursInRange;
    public LayerMask detectionLayer;
    public List<GameObject> FamilyFish;
    public LayerMask enemyLayer;
    private SpawnRorids Spawn;

    public void Start()
    {
        //for (int i = 0; i < Spawn.FamilyFishes.Count; i++)
        //{
        //    FamilyFish.Add(Spawn.FamilyFishes[i]);
        //}
    }

    public List<GameObject> FindNewNeighbours()
    {
        neighboursInRange.Clear();

        Collider[] colliders = Physics.OverlapSphere(transform.position, dectectionRange, detectionLayer);
        foreach (var VARIABLE in colliders)
        {
            GameObject boid = VARIABLE.gameObject;
            if (boid != gameObject)
            {
                RaycastHit hit;
                Vector3 dir = boid.transform.position - transform.position;

                if (Physics.Raycast(transform.position, dir, out hit, dectectionRange, detectionLayer))
                {
                    if (hit.collider.gameObject == boid)
                    {
                        neighboursInRange.Add(boid);
                    }
                }
            }
        }

        return neighboursInRange;
    }

    public bool FindEnemies()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, enemyDectRange, enemyLayer);
        if (colliders.Length >= 1)
        {
            return true;
        }
        return false;
    }
    public List<GameObject> FindNewEnemies()
    {
        neighboursInRange.Clear();

        Collider[] colliders = Physics.OverlapSphere(transform.position, enemyDectRange, enemyLayer);
        foreach (var VARIABLE in colliders)
        {
            GameObject boid = VARIABLE.gameObject;
            RaycastHit hit;
            Vector3 dir = boid.transform.position - transform.position;
            if (Physics.Raycast(transform.position, dir, out hit, enemyDectRange, enemyLayer))
            {
                if (hit.collider.gameObject == boid)
                {
                    neighboursInRange.Add(boid);
                }
            }
        }

        return neighboursInRange;
    }
    
    public List<GameObject> PersonalBubble()
    {
        neighboursInRange.Clear();

        Collider[] colliders = Physics.OverlapSphere(transform.position, personalBubbleRange, detectionLayer);
        foreach (var VARIABLE in colliders)
        {
            GameObject boid = VARIABLE.gameObject;
            if (boid != gameObject)
            {
                RaycastHit hit;
                Vector3 dir = boid.transform.position - transform.position;

                if (Physics.Raycast(transform.position, dir, out hit, personalBubbleRange, detectionLayer))
                {
                    if (hit.collider.gameObject == boid)
                    {
                        neighboursInRange.Add(boid);
                    }
                }
            }
        }

        return neighboursInRange;
    }

    public List<GameObject> FindFamilyNemoStyle()
    {
        neighboursInRange.Clear();

        Collider[] colliders = Physics.OverlapSphere(transform.position, dectectionRange, detectionLayer);
        List<GameObject> Family = new List<GameObject>();
        foreach (var VARIABLE in colliders)
        {
            for (int i = 0; i < FamilyFish.Count; i++)
            {
                if (VARIABLE.gameObject == FamilyFish[i].gameObject)
                {
                    Family.Add(VARIABLE.gameObject);
                }
            }
        }
        foreach (var VARIABLE in Family)
        {
            GameObject boid = VARIABLE;
            if (boid != gameObject)
            {
                RaycastHit hit;
                Vector3 dir = boid.transform.position - transform.position;

                if (Physics.Raycast(transform.position, dir, out hit, dectectionRange, detectionLayer))
                {
                    if (hit.collider.gameObject == boid)
                    {
                        neighboursInRange.Add(boid);
                    }
                }
            }
        }
        return neighboursInRange;
    }
}
