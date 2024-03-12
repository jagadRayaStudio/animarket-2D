using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;

        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
