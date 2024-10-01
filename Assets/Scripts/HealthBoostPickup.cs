using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoostPickup : MonoBehaviour
{
    public int healthRestoreAmount = 30; // Amount of health restored

    // Function to restore health when the object is hit by the raycast
    public void OnHitByRaycast(GameObject player)
    {
        HealthSystem healthSystem = player.GetComponent<HealthSystem>();

        if (healthSystem != null)
        {
            // Restore health to the player
            healthSystem.RestoreHealth(healthRestoreAmount);
            Debug.Log("Health Restored!");

            // Destroy the health pickup after being used
            Destroy(gameObject);
        }
    }
}
