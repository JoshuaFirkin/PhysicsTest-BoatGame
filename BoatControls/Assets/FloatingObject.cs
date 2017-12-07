using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloatingObject : MonoBehaviour
{
    public Rigidbody rb;
    public Transform floatPoint;

    public const float waterLevel = 12.0f;
    public float floatLevel = 10.0f;
    public float density = 0.125f;
    public float sinkRate = 4.0f;

    private float forceFactor;
    private Vector3 floatForce;

    private void FixedUpdate()
    {
        forceFactor = 1.0f - ((floatPoint.position.y - waterLevel) / floatLevel);

        if (forceFactor > 0.0f)
        {
            AddBuoyForce();
        }
    }

    private void AddBuoyForce()
    {
        floatForce = -Physics.gravity * (forceFactor - rb.velocity.y * density);
        floatForce += new Vector3(0.0f, -sinkRate, 0.0f);
        rb.AddForceAtPosition(floatForce, floatPoint.position);
    }
}
