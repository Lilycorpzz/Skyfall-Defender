using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shieldObject;   // Reference to the shield object
    public float shieldDuration = 5f; // How long the shield lasts

    // Method to activate the shield
    public void ActivateShield(float duration)
    {
        StartCoroutine(ShieldRoutine(duration));
    }

    // Coroutine to handle shield behavior over time
    private IEnumerator ShieldRoutine(float duration)
    {
        // Activate shield
        shieldObject.SetActive(true);

        // Set the player’s layer to the shielded layer
        // Ensure the layer number is between 0 and 31
        int shieldedLayer = 8; // Example layer for shielded player (ensure this is valid)
        gameObject.layer = shieldedLayer;

        // Wait for the duration of the shield
        yield return new WaitForSeconds(duration);

        // Deactivate shield and reset layer
        shieldObject.SetActive(false);
        gameObject.layer = 0; // Reset to default layer (usually 0 is the default layer)
    }

}
