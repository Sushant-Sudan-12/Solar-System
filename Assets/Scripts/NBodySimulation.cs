using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBodySimulation : MonoBehaviour
{
    CelestialBody[] bodies;

    void Awake(){
        bodies = FindObjectsOfType<CelestialBody>();
        Time.fixedDeltaTime = Universe.timeStep;
    }

    void FixedUpdate(){
        for(int i = 0;i< bodies.Length;i++){
            bodies[i].UpdateVelocity(bodies);
        }
        for(int i = 0;i< bodies.Length;i++){
            bodies[i].UpdatePosition();
        }
    }
}
