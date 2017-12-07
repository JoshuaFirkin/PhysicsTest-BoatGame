using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatController : MonoBehaviour
{
    public float moveSpeed = 100.0f;
    public float rotSpeed = 0.01f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotSpeed * Time.deltaTime);
            rb.AddForceAtPosition(transform.forward * moveSpeed * Time.deltaTime, transform.position);
        }
    }

}
