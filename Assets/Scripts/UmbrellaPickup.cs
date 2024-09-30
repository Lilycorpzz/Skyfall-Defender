using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaPickup : MonoBehaviour
{
    public float shieldDuration = 5f; // Duration the umbrella shield lasts
    private bool shieldActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShield playerShield = other.GetComponent<PlayerShield>();

            if (playerShield != null)
            {
                // Activate the shield and start the timer
                playerShield.ActivateShield(shieldDuration);
                Debug.Log("Umbrella Shield Activated!");

                // Destroy the umbrella pickup after being used
                Destroy(gameObject);
            }
        }
    }
}
