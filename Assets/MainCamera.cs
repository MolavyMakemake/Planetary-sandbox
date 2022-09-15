using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform focus;

    // Update is called once per frame
    void Update()
    {
        if (focus != null)
        {
            Quaternion targetRotation = Quaternion.LookRotation(focus.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 90);
        }
    }
}
