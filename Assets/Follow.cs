using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;        // Reference to the player's Transform
    public float speed = 5f;       // Movement speed
    public float minDistance = 1f;  // Minimum distance to maintain from player

    void Update()
    {
        if (target != null)
        {
            // Calculate distance between follower and target
            float distance = Vector3.Distance(transform.position, target.position);

            // Only move if we're further than the minimum distance
            if (distance > minDistance)
            {
                // Calculate direction to the target
                Vector3 direction = (target.position - transform.position).normalized;
                
                // Move towards the target
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }
}
