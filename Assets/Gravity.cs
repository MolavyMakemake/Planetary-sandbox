using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float G = 1;
    static public List<Body> bodies = new List<Body>();

    void Solve(Body A, Body B)
    {
        if (A.isStatic && B.isStatic)
            return;

        Vector3 AB = B.position - A.position;

        float I = Time.fixedDeltaTime * G * A.mass * B.mass / AB.sqrMagnitude;

        Vector3 n = AB.normalized;

        if (!A.isStatic)
        {
            A.velocity += I / A.mass * n;
            A.position += Time.fixedDeltaTime * A.velocity;
        }
        if (!B.isStatic)
        {
            B.velocity -= I / B.mass * n;
            B.position += Time.fixedDeltaTime * B.velocity;
        }
    }

    void FixedUpdate()
    {
        int nBodies = bodies.Count;

        for (int i = 0; i < nBodies; i++)
            for (int j = i + 1; j < nBodies; j++)
                Solve(bodies[i], bodies[j]);

        foreach (Body b in bodies)
            b.UpdatePosition();
    }
}
