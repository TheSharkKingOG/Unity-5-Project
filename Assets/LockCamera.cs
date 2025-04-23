using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 2f;
    private float xRotation = 0f;
    private float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Handle vertical rotation (looking up and down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent over-rotation

        // Handle horizontal rotation (looking left and right)
        yRotation += mouseX;

        // Apply both rotations to the camera
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    // Allow unlocking cursor with Escape key
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
