using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float G = 1;

    Vector3 v = Vector3.left / 1.5f;

    void FixedUpdate()
    {
        Vector3 p = transform.position;
        v -= G * p.normalized * Time.fixedDeltaTime / p.sqrMagnitude;
        transform.position += Time.fixedDeltaTime * v;

        transform.rotation = Quaternion.LookRotation(-transform.position);
    }
}
