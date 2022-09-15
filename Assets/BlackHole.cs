using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float rotation;
    public float rotationSpeed;

    Material _material;

    private void OnEnable()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    private void FixedUpdate()
    {
        rotation += Time.fixedDeltaTime * rotationSpeed;
        _material.SetFloat("_Disk_rotation", rotation);
    }
}
