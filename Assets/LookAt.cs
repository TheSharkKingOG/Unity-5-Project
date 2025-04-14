using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Transform target; // Reference to the player's transform
    [SerializeField] private bool lockXRotation = true; // Option to lock X rotation
    [SerializeField] private bool lockYRotation = false; // Option to lock Y rotation
    [SerializeField] private bool lockZRotation = true; // Option to lock Z rotation
    
    private Vector3 originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Store the original rotation
        originalRotation = transform.eulerAngles;
        
        // If no target is assigned, try to find the player
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Calculate the direction to look at
            Vector3 direction = target.position - transform.position;
            
            // Create the rotation
            Quaternion rotation = Quaternion.LookRotation(direction);
            
            // Convert to euler angles
            Vector3 eulerAngles = rotation.eulerAngles;
            
            // Apply rotation locks
            if (lockXRotation) eulerAngles.x = originalRotation.x;
            if (lockYRotation) eulerAngles.y = originalRotation.y;
            if (lockZRotation) eulerAngles.z = originalRotation.z;
            
            // Apply the final rotation
            transform.rotation = Quaternion.Euler(eulerAngles);
        }
    }
}
