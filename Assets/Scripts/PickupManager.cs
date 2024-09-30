using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    // Array of prefabs for different pickup types
    public GameObject[] pickupPrefabs;

    public float spawnInterval = 10f;  // Time between spawns
    public float spawnRange = 8f;      // X and Z range for spawning
    public float minHeight = 10f;      // Minimum Y position where pickups spawn
    public float maxHeight = 15f;      // Maximum Y position where pickups spawn
    public float pickupLifetime = 8f;  // Destroy the pickup after this time if not collected

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnRandomPickup();
            timer = 0f;
        }
    }

    // Spawns a random pickup from the pickupPrefabs array
    void SpawnRandomPickup()
    {
        // Select a random prefab from the array
        int randomIndex = Random.Range(0, pickupPrefabs.Length);
        GameObject pickupToSpawn = pickupPrefabs[randomIndex];

        // Randomize the spawn position within the given range
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);
        float randomY = Random.Range(minHeight, maxHeight); // Random height for spawn
        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

        // Spawn the selected pickup at the random position
        GameObject spawnedPickup = Instantiate(pickupToSpawn, spawnPosition, Quaternion.identity);

        // Add Rigidbody if it doesn't have one to simulate falling
        Rigidbody rb = spawnedPickup.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = spawnedPickup.AddComponent<Rigidbody>();
        }

        // Set the pickup's downward velocity
        rb.velocity = new Vector3(0, -Random.Range(2f, 5f), 0);  // Vary the fall speed

        // Destroy the pickup after a set time if not collected
        Destroy(spawnedPickup, pickupLifetime);
    }
}
