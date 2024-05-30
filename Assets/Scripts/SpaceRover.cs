using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class SpaceRover : MonoBehaviour
{
    public float thrustForce = 10f;
    public float rotationSpeed = 100f;
    public float drag = 0.1f;
    
    private Rigidbody rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.drag = drag; 
    }

    void Update(){
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * thrustForce);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * thrustForce);
        }

        
    }

    void HandleRotation()
    {
        float rotation = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            rotation = rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotation = -rotationSpeed * Time.deltaTime;
        }

        rb.AddTorque(transform.up * rotation);
    }

}
