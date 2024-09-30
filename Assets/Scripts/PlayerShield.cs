using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shieldVisual; // Visual representation of the shield (umbrella)
    private bool shieldActive = false;

    void Start()
    {
        shieldVisual.SetActive(false); // Hide the shield initially
    }

    public void ActivateShield(float duration)
    {
        if (!shieldActive)
        {
            StartCoroutine(ShieldRoutine(duration));
        }
    }

    private IEnumerator ShieldRoutine(float duration)
    {
        shieldActive = true;
        shieldVisual.SetActive(true); // Show the shield

        // Deflect falling objects by destroying them if they hit the shield
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Obstacle"), true);

        yield return new WaitForSeconds(duration);

        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Obstacle"), false);

        shieldVisual.SetActive(false); // Hide the shield
        shieldActive = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (shieldActive && other.CompareTag("Obstacle"))
        {
            // Destroy any falling object that collides with the shield
            Destroy(other.gameObject);
        }
    }
}
