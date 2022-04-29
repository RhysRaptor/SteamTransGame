using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMouse : MonoBehaviour
{
    public bool rotateX;

    public bool rotateY;

    public float sensitivity;

    void Update()
    {
        float xRot = rotateX ? (Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime) : 0;
        float yRot = rotateY ? (Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime) : 0;
        transform.Rotate(Vector3.up, xRot, Space.Self);
        transform.Rotate(Vector3.right, yRot, Space.World);
    }
}
