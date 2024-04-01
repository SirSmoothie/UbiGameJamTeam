using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAlignment : MonoBehaviour
{
    private FishFriendRadar neighbours;
    public float force = 0.2f;

    private void Start()
    {
        neighbours = GetComponent<FishFriendRadar>();
    }

    private void FixedUpdate()
    {
        var newNeighbours = (neighbours.FindNewNeighbours());
        Vector3 targetDirection = CalculateMove(newNeighbours);

        Vector3 cross = Vector3.Cross(transform.right, targetDirection);
            
        GetComponent<Rigidbody>().AddTorque(cross * force);
    }

    public Vector3 CalculateMove(List<GameObject> neighbours)
    {
        if (neighbours.Count <= 0)
        {
            return Vector3.zero;
        }

        Vector3 alignmentMove = Vector3.zero;
        foreach (var gameObject in neighbours)
        {
            alignmentMove += gameObject.transform.right;
        }

        alignmentMove /= neighbours.Count;
            
        return alignmentMove;
    }
}
