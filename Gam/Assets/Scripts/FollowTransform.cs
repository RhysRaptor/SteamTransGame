using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public Transform target;
    public Vector3 positionOffset;

    public bool followPosition;

    public bool followRotation;

    public bool smoothPosition;

    public bool smoothRotation;

    public float smoothPositionMult;
    public float smoothRotationMult;

    // Update is called once per frame
    void Update()
    {
        if (followPosition)
        {
            if (smoothPosition)
                transform.position = Vector3.MoveTowards(transform.position, target.position + positionOffset, smoothPositionMult * Time.deltaTime);
            else
                transform.position = target.position + positionOffset;
        }

        if (followRotation)
        {
            if (smoothRotation)
                transform.rotation =
                    Quaternion.Slerp(transform.rotation, target.rotation, smoothRotationMult * Time.deltaTime);
            else
                transform.rotation = target.rotation;
        }
    }
}
