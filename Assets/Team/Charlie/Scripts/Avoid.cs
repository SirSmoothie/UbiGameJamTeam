using UnityEngine;

public class Avoid : MonoBehaviour
{
    public Rigidbody rb;
    public LayerMask layerMask;
    public float distance = 10f;
    public float turnSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // AvoidObstacle(); 
    }


    public void AvoidObstacle()
    {
        if (Physics.Raycast(transform.position, transform.forward, distance, layerMask))
        {
            rb.AddRelativeTorque(0, turnSpeed, 0);
        }
    }
}