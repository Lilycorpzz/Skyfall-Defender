using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoostPickup : MonoBehaviour
{
    public int healthRestoreAmount = 30; // Amount of health restored

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthSystem healthSystem = other.GetComponent<HealthSystem>();

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
}
