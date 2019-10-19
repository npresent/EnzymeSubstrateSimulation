using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    public Rigidbody rb;
    public float minForce = 1, maxForce = 50;

    // Update is called once per frame
    void FixedUpdate()
    {
        float force = Random.Range(minForce, maxForce);
        rb.AddForce(transform.forward * force * Time.fixedDeltaTime);
    }
}
