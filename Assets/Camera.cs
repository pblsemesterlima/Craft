using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Target kamera (karakter)
    public float distance = 4f; // Jarak kamera dari karakter
    public float height = 1f; // Ketinggian kamera dari tanah
    public float damping = 0.1f; // Kecepatan mengikuti pergerakan karakter

    private Vector3 currentVelocity = Vector3.zero; // Kecepatan kamera untuk smooth damping

    void LateUpdate()
    {
        // Posisi kamera yang diinginkan di belakang dan sedikit di atas karakter
        Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;

        // Gunakan damp untuk memuluskan pergerakan kamera
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, damping);

        // Kamera selalu melihat ke arah karakter
        transform.LookAt(target);
    }
}
