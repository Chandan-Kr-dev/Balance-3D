using UnityEngine;

public class PLayerScript : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    public Transform cameraTransform; // Assign your main camera's transform in the Inspector

    void Update()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ensure movement is only in the XZ plane (ignore vertical movement)
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection += forward;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection -= right;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection += right;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection -= forward;
        }

        rb.AddForce(moveDirection * speed, ForceMode.Acceleration);
    }
}
