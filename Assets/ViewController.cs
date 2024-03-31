using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    private Rigidbody rb;
    public bool isFacingRight;
    public GameObject view;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.velocity.x < 0)
        {
            if (isFacingRight)
            {
                FlipView();
            }
        }
        else
        {
            if (!isFacingRight)
            {
                FlipView();
            }
        }
    }

    void FlipView()
    {
        isFacingRight = !isFacingRight;
        view.transform.Rotate(180f,0f,0f);
    }
}
