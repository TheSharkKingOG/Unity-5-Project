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
    }

    void FixedUpdate()
    {
        // Apply custom gravity
        Vector3 gravity = Physics.gravity * gravityScale;
        
        // Apply stronger gravity when falling for better game feel
        if (rb.velocity.y < 0)
        {
            gravity.y *= fallMultiplier;
        }

        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
