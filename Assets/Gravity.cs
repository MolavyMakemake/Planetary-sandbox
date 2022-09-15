using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float G = 1;
    public float t = 100;
    static public List<Body> bodies = new List<Body>();

    void Solve(Body A, Body B, float dT)
    {
        if (A.isStatic && B.isStatic)
            return;

        Vector3 AB = B.position - A.position;

        float I = dT * G * A.mass * B.mass / AB.sqrMagnitude;

        Vector3 n = AB.normalized;

        if (!A.isStatic)
        {
            A.velocity += I / A.mass * n;
            A.position += dT * A.velocity;
        }
        if (!B.isStatic)
        {
            B.velocity -= I / B.mass * n;
            B.position += dT * B.velocity;
        }
    }

    void FixedUpdate()
    {
        float dT = t * Time.fixedDeltaTime;
        int nBodies = bodies.Count;

        for (int i = 0; i < nBodies; i++)
            for (int j = i + 1; j < nBodies; j++)
                Solve(bodies[i], bodies[j], dT);

        foreach (Body b in bodies)
            b.UpdatePosition();
    }
}
