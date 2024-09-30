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

    public float initialSpeed = 5f;   // Initial speed of falling objects
    public float speedIncreaseRate = 0.1f; // How much the speed increases over time
    public float spawnIntervalDecreaseRate = 0.01f; // How much spawn interval decreases over time
    public float objectLifetime = 4f; // Object gets destroyed after 4 seconds if it’s still in the scene

    public int damage = 10;

    private float timer = 0f;
    private float currentSpeed;

    void Start()
    {
        currentSpeed = initialSpeed;  // Start with the initial object speed
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnRandomObject();
            timer = 0f;

            // Gradually decrease spawn interval, making objects spawn faster
            spawnInterval = Mathf.Max(0.2f, spawnInterval - spawnIntervalDecreaseRate);  // Never let it go below 0.2 seconds
        }

        // Gradually increase the speed of falling objects
        currentSpeed += speedIncreaseRate * Time.deltaTime;
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
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Set the object's falling speed by adding a downward force or modifying velocity
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = new Vector3(0, -currentSpeed, 0);  // Make the object fall downward faster over time
        }

        // Destroy the object after a set time (objectLifetime seconds)
        Destroy(spawnedObject, objectLifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthSystem>().TakeDamage(damage);
            Destroy(gameObject); // Destroy the object after impact
        }
    }

}
