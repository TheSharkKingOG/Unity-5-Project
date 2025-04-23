using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input axes
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // A & D keys
        float verticalInput = Input.GetAxisRaw("Vertical");     // W & S keys

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        
        // Apply movement
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if we're colliding with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
