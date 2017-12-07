using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyancyScript : MonoBehaviour
{

    public Rigidbody[] objects;
    const float yPos = 12.0f;

    //Buoyancy variables.
    private const float density = 1f;
    private const float gravity = 5.0f;



	void FixedUpdate ()
    {
        foreach (var obj in objects)
        {
            if (obj.transform.position.y < yPos)
            {
                AddBuoyForce(obj);
            }
        }
	}


    void AddBuoyForce(Rigidbody body)
    {
        //F = VDG
        Vector3 force = new Vector3
            (
            0,
            gravity * (yPos - body.transform.position.y),
            0
            );

        body.AddForce(force);
    }
}
