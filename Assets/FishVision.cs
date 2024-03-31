using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishVision : MonoBehaviour
{
    public int noOfRays;
    public float maxAngle;
    public float rayRange;
    public LayerMask mask;
    public AnimationCurve distanceMultiplier;
    
    private RaycastHit hit;
    
    public float FindNearestNonObstucted()
    {
        var TurnDir = 0f;
        for (int i = -noOfRays/2; i <= noOfRays/2; i++)
        {
            // Very simple. Doesn't take any tilting or pitching into account, but is fine for horizontal only AIs
            float spreadAngle = -maxAngle/(noOfRays-1);
            Vector3 dir = Quaternion.Euler(0, 0, i*spreadAngle) * transform.right;
            //Debug.DrawRay(transform.position, dir * range, Color.yellow);
            if (Physics.Raycast(transform.localPosition, dir, out hit, rayRange, mask))
            {
                var dist = hit.distance/rayRange;
                TurnDir -= spreadAngle-(spreadAngle*distanceMultiplier.Evaluate(dist));
                //Debug.Log(dist);
            }
            else
            {
                var dist = hit.distance / rayRange; 
                TurnDir += spreadAngle-(spreadAngle*distanceMultiplier.Evaluate(dist));
            }
        }
        Debug.Log(TurnDir);
        return TurnDir;
    }

    public float DistanceToObstical()
    {
        float dist = 0;
        
        
        if (Physics.Raycast(transform.localPosition, transform.right, out hit, rayRange, mask))
        {
            dist = hit.distance / rayRange; 
        }
        //Debug.Log(dist);
        return dist;
    }

    public bool IsForwardBlocked()
    {
        if (Physics.Raycast(transform.localPosition, transform.right, out hit, rayRange, mask))
        {
            return true;
        }

        return false;
    }

    public float ForwardDist()
    {
        float dist = 0;
        if (Physics.Raycast(transform.localPosition, transform.right, out hit, rayRange, mask))
        {
            dist = hit.distance/rayRange;
        }

        return dist;
    }
}
