using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public float mass;
    public float radius;
    public Vector3 initialVelocity;
    Vector3 currentVelocity;
    private Rigidbody rb;

    void Awake(){
        rb = GetComponent<Rigidbody>();
        if(rb != null){
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.mass = mass;
        rb.position = transform.position;
        currentVelocity = initialVelocity;
    }

    public void UpdateVelocity(CelestialBody[] allBodies){
        foreach(var otherBody in allBodies){
            if(otherBody != this){
                float sqrtDistance = (otherBody.rb.position - rb.position).sqrMagnitude;
                Vector3 forceDir =(otherBody.rb.position - rb.position).normalized;
                Vector3 force = forceDir *Universe.G* mass*otherBody.mass/sqrtDistance;
                Vector3 acceleration = force/mass;
                currentVelocity += Universe.timeStep*acceleration;
            }
        }    

    }

    public void UpdatePosition(){
        rb.position += currentVelocity*Universe.timeStep;
    }


}

public static class Universe{
    public const float G = 6.67430e-11f;
    public const float timeStep = 0.01f;
}




