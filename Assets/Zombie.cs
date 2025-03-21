using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int health = 100; // The zombie starts with 100 health points

    void TakeDamage(int damage)
    {
        health -= damage; // Subtract the damage from the zombie's health
        Debug.Log("Zombie took damage! Remaining health: " + health);

        if (health <= 0)
        {
            Die(); // Call the Die function when health is 0 or less
        }
    }

    void Die()
    {
        Debug.Log("Zombie is dead!");
        Destroy(gameObject); // Removes the zombie from the scene
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // Check if the object colliding is tagged "Bullet"
        {
            TakeDamage(10); // Each bullet does 10 damage
            Destroy(collision.gameObject); // Destroy the bullet after it hits
        }
    }
}
