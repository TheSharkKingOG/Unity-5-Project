using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float gravityScale = 1f;
    [SerializeField] private float fallMultiplier = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Make sure we don't use Unity's default gravity
        rb.useGravity = false;
        // Freeze rotation to prevent tipping over
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        // Store current horizontal velocity
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        
        // Apply custom gravity (vertical only)
        float gravityForce = Physics.gravity.y * gravityScale;
        
        // Apply stronger gravity when falling
        if (rb.velocity.y < 0)
        {
            gravityForce *= fallMultiplier;
        }

        // Apply gravity force while preserving horizontal movement
        rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y + gravityForce * Time.fixedDeltaTime, horizontalVelocity.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
