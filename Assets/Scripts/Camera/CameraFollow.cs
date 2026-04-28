using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;           // Masukkan GameObject Ninja ke sini
    public Vector3 offset = new Vector3(0, 2, -10); // Jarak kamera dari Ninja

    [Header("Smooth Settings")]
    public float smoothSpeed = 0.125f; // Semakin kecil, semakin halus/lambat gerakannya

    private void LateUpdate()
    {
        if (target == null) return;

        // Tentukan posisi tujuan (posisi Ninja + jarak offset)
        Vector3 desiredPosition = target.position + offset;

        // Gunakan Lerp untuk transisi posisi yang halus
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Terapkan posisi baru ke Kamera
        transform.position = smoothedPosition;
    }
}