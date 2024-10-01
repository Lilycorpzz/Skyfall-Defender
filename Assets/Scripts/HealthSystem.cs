using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthBar;
    public int damageAmount = 10;  // Damage to apply when hit by an obstacle

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        // Optional: Add any additional health-related updates here
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Debug.Log("Player Defeated");
            SceneManager.LoadScene("Credit");
        }
    }

    // This method will detect collisions with objects tagged as "Obstacle"
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fall object"))
        {
            // Call TakeDamage when hitting an obstacle
            TakeDamage(damageAmount);

            // Optional: Destroy the obstacle or trigger other behavior
            Destroy(other.gameObject);
        }
    }

    // Method to restore health (e.g., from a health pickup)
    public void RestoreHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        healthBar.value = currentHealth;
    }

}
