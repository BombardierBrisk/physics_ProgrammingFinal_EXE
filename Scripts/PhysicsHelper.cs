using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsHelper
{
    //helper class to solve kinematic equations
    //kinematic equations

    // d = Vi*t + 0.5at^2
    // Vf^2 = Vi^2 + 2ad
    // Vf = Vi + at
    // d = ((Vi + Vf)*0.5) * t

    public static Vector3 CalculateInitialVelocity(Vector3 displacement, float time, Vector3 acceleration)
    {
        // d = Vi*t + 0.5at^2
        // d - 0.5at^2 = Vi*t
        // Vi = (d - 0.5at^2)/t

        if(time < Mathf.Epsilon)
        {
            return Vector3.zero;
        }

        return (displacement - (0.5f*acceleration*(time*time)))/time;
    }

    public static Vector3 CalculateForce(Vector3 initialVelocity,Vector3 finalVelocity,float time,float mass)
    {
        if(time < Mathf.Epsilon)
        {
            return Vector3.zero;
        }

        return ((finalVelocity - initialVelocity) / time) * mass;
    }
}
