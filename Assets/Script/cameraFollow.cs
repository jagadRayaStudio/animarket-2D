using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cameraFollow : MonoBehaviour
{
    private Transform target; // Mengubah akses variabel target menjadi private

    public Vector3 offset;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null) // Periksa apakah target tidak null sebelum mengikuti
        {
            Vector3 targetPosition = target.position + offset;
            targetPosition.z = transform.position.z;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    public void SetTarget(Transform newTarget) // Menambahkan metode untuk mengatur target dari luar skrip
    {
        target = newTarget;
    }
}

