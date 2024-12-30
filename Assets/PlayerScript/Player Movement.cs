using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    public Camera cam;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // Get camera's forward and right vectors for movement relative to camera
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        
        // Remove vertical component to keep movement horizontal
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Calculate movement direction based on camera orientation
        Vector3 movement = (forward * verticalInput + right * horizontalInput) * moveSpeed;
        
        // Move the player
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        
        // Only rotate if there's movement input
        if (movement != Vector3.zero)
        {
            // Create rotation towards movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 0.15f));
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void Jump()
    {
        // Add your jump logic here
        // For example, you can apply an upward force to the Rigidbody
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}

