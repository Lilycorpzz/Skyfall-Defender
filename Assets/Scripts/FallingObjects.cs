using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    // Array of prefabs for different object types
    public GameObject[] objectPrefabs;
    public float spawnInterval = 1f;  // Time between spawns
    public float spawnRange = 8f;     // X and Z range for spawning
    public float minHeight = 10f;     // Y position where objects spawn
    public float maxHeight = 15f;     // Varying spawn height to add randomness

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnRandomObject();
            timer = 0f;
        }
    }

    // Spawns a random object from the objectPrefabs array
    void SpawnRandomObject()
    {
        // Select a random prefab from the array
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject objectToSpawn = objectPrefabs[randomIndex];

        // Randomize the spawn position within the given range
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);
        float randomY = Random.Range(minHeight, maxHeight); // Random height for spawn
        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

        // Spawn the selected object at the random position
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
