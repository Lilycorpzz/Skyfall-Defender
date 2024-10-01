using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaPickup : MonoBehaviour
{
    public float shieldDuration = 5f; // How long the shield lasts

    // Function to activate the shield when hit by a raycast
    public void OnHitByRaycast(GameObject player)
    {
        // Find the PlayerShield component attached to the player and activate the shield
        PlayerShield playerShield = player.GetComponent<PlayerShield>();

        if (playerShield != null)
        {
            playerShield.ActivateShield(shieldDuration);
            Debug.Log("Shield Activated for " + shieldDuration + " seconds!");

            // Destroy the umbrella pickup after use
            Destroy(gameObject);
        }
    }
}
