using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public bool isStatic;

    public float mass;
    public Vector3 velocity;
    public Vector3 position;

    private void OnEnable()
    {
        position = transform.position;
        Gravity.bodies.Add(this);
    }

    public void UpdatePosition()
    {
        if (!isStatic)
            transform.position = position;
    }
}
