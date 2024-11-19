using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan gerak karakter
    public float rotationSpeed = 720f; // Kecepatan rotasi karakter
    private Animator animator; // Referensi ke Animator
    private Vector3 moveDirection; // Arah gerakan
    public Transform cameraTransform; // Referensi ke kamera

    void Start()
    {
        // Ambil komponen Animator dari GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Ambil input dari keyboard (WASD)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Tentukan arah pergerakan karakter berdasarkan input
        Vector3 forward = cameraTransform.forward; // Arah depan kamera
        forward.y = 0f; // Mengabaikan pergerakan vertikal (sumbu Y)
        forward.Normalize(); // Normalisasi agar kecepatan pergerakan konstan

        Vector3 right = cameraTransform.right; // Arah kanan kamera
        right.y = 0f; // Mengabaikan pergerakan vertikal (sumbu Y)
        right.Normalize(); // Normalisasi agar kecepatan pergerakan konstan

        // Tentukan arah gerakan berdasarkan input horizontal dan vertical
        moveDirection = (forward * vertical + right * horizontal).normalized;

        // Jika ada input gerakan
        if (moveDirection.magnitude > 0.1f)
        {
            // Aktifkan animasi Running
            animator.SetBool("isRunning", true);

            // Rotasi karakter ke arah gerakan
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            // Gerakkan karakter
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            // Jika tidak ada input, kembali ke animasi Idle
            animator.SetBool("isRunning", false);
        }
    }
}
