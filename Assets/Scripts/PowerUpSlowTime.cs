using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlowTime : MonoBehaviour
{
    public float slowDuration = 5f;
    public float fallingObjectSlowFactor = 0.5f; // The factor by which falling objects are slowed

    // Method to trigger slow time effect when hit by a raycast
    public void OnHitByRaycast()
    {
        StartCoroutine(SlowTime());
        Destroy(gameObject); // Destroy power-up after collection
    }

    // Coroutine to apply the slow time effect
    IEnumerator SlowTime()
    {
        // Slow down the overall game time
        Time.timeScale = 0.5f;

        // Reference all the falling objects and slow them down
        FallingObjects[] fallingObjects = FindObjectsOfType<FallingObjects>();
        foreach (FallingObjects obj in fallingObjects)
        {
            obj.AdjustFallingSpeed(fallingObjectSlowFactor); // Slow down falling objects
        }

        // Wait for the slowDuration time in real-world time (ignores timeScale)
        yield return new WaitForSecondsRealtime(slowDuration);

        // Reset the game time
        Time.timeScale = 1f;

        // Restore the falling object speed to normal
        foreach (FallingObjects obj in fallingObjects)
        {
            obj.AdjustFallingSpeed(1f); // Reset falling objects to normal speed
        }
    }

}
