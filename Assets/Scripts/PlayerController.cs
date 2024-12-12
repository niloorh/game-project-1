using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(
            Input.GetAxis("Horizontal") * Speed,
            rb.velocity.y,
            Input.GetAxis("Vertical") * Speed);
        rb.velocity = v;
    }
}
