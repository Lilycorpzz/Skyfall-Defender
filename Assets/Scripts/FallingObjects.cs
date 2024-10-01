using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float spawnInterval = 1f;
    public float spawnRange = 3f;
    public float minHeight = 10f;
    public float maxHeight = 15f;

    public float initialSpeed = 5f;
    public float speedIncreaseRate = 0.1f;
    public float spawnIntervalDecreaseRate = 0.01f;
    public float objectLifetime = 4f;

    private float currentSpeed;
    private float timer = 0f;

    void Start()
    {
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnRandomObject();
            timer = 0f;

            spawnInterval = Mathf.Max(0.2f, spawnInterval - spawnIntervalDecreaseRate);
        }

        currentSpeed += speedIncreaseRate * Time.deltaTime;
    }

    // Spawns a random object
    void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject objectToSpawn = objectPrefabs[randomIndex];

        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);
        float randomY = Random.Range(minHeight, maxHeight);

        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = new Vector3(0, -currentSpeed, 0);
        }

        Destroy(spawnedObject, objectLifetime);
    }

    // Method to adjust the falling speed when slow time is applied
    public void AdjustFallingSpeed(float speedFactor)
    {
        currentSpeed = initialSpeed * speedFactor;
    }

}
