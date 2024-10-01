using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaPickup : MonoBehaviour
{
    public float shieldDuration = 5f; // How long the shield lasts

    void OnTriggerEnter(Collider other)
    {
        // Assuming the player is tagged "Player"
        if (other.CompareTag("Player"))
        {
            // Activate the player's shield
            PlayerShield playerShield = other.GetComponent<PlayerShield>();

            if (playerShield != null)
            {
                playerShield.ActivateShield(shieldDuration);
            }

            // Destroy the pickup after use
            Destroy(gameObject);
        }
    }
}
