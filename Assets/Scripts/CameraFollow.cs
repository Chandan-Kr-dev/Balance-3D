using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Object to follow
    public float distance = 5.0f; // Distance from target
    public float mouseSensitivity = 3.0f; // Mouse sensitivity
    public float rotationSmoothTime = 0.1f; // Smoothing factor
    public float fixedHeight = 2.0f; // Fixed height for the camera
    public float maxRotationAngle = 60f; // Maximum rotation in either direction

    private float rotationX = 0f; // Stores horizontal rotation
    private Vector2 rotationSmoothVelocity; // Helps with smoothing

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("CameraFollow: No target assigned!");
            return;
        }

        // Set initial rotation
        rotationX = transform.eulerAngles.y;

        Cursor.lockState = CursorLockMode.Locked; // Lock cursor for FPS-like control
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Get mouse input for horizontal rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        // Apply horizontal rotation and clamp within -60 to 60 degrees
        rotationX += mouseX;
        rotationX = Mathf.Clamp(rotationX, -maxRotationAngle, maxRotationAngle);

        // Smooth rotation interpolation
        float smoothedRotationX = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationX, ref rotationSmoothVelocity.x, rotationSmoothTime);

        // Calculate new camera position
        Quaternion rotationQuaternion = Quaternion.Euler(0, smoothedRotationX, 0); // Lock vertical rotation
        Vector3 targetPosition = target.position - (rotationQuaternion * Vector3.forward * distance);

        // Apply transformations with fixed height
        transform.position = new Vector3(targetPosition.x, targetPosition.y+fixedHeight, targetPosition.z);
        transform.LookAt(new Vector3(target.position.x, targetPosition.y+fixedHeight, target.position.z)); // Keep looking at the target

    }
}
