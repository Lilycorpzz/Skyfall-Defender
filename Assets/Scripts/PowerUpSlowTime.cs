using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlowTime : MonoBehaviour
{
    public float slowDuration = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SlowTime());
            Destroy(gameObject); // Destroy power-up after collection
        }
    }

    IEnumerator SlowTime()
    {
        Time.timeScale = 0.5f; // Slow down the game
        yield return new WaitForSecondsRealtime(slowDuration);
        Time.timeScale = 1f; // Reset the time scale
    }

}
