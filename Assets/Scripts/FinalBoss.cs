using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public GameObject finalBoss;        // Final boss object to spawn
    public float swipeForce = 500f;
    public float bossSpawnTime = 60f;   // Time after which the final boss spawns
    public float spawnRange = 3f;       // X and Z range for spawning
    public float minHeight = 10f;       // Y position where the boss spawns
    public float maxHeight = 15f;       // Random Y position for the boss spawn
    public float initialSpeed = 5f;   // Initial speed of falling objects
    public float speedIncreaseRate = 0.1f; // How much the speed increases over time
    private Rigidbody rb;
    private bool bossSpawned = false;   // To ensure the boss only spawns once
    public float despawnTime = 2f;
    private float currentSpeed;
    void Start()
    {
        // Get the Rigidbody component attached to the falling object
        rb = GetComponent<Rigidbody>();
        StartCoroutine(SpawnFinalBoss());  // Start the timer for boss spawn
    }

    IEnumerator SpawnFinalBoss()
    {
        yield return new WaitForSeconds(bossSpawnTime);  // Wait for the specified time

        SpawnBoss();  // Spawn the final boss
        bossSpawned = true;  // Ensure the boss doesn't spawn again
    }

    void SpawnBoss()
    {
        // Randomize the spawn position within the given range
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);
        float randomY = Random.Range(minHeight, maxHeight);  // Random Y position for spawn

        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

        // Spawn the final boss at the random position
        GameObject spawnedBoss = Instantiate(finalBoss, spawnPosition, Quaternion.identity);  // Spawn the final boss

        Rigidbody rb = spawnedBoss.GetComponent<Rigidbody>();  // Get the Rigidbody from the instantiated boss object
        if (rb != null)
        {
            rb.velocity = new Vector3(0, -currentSpeed, 0);  // Make the boss fall downward
        }
        Debug.Log("Final Boss Spawned!");
    }

    // Update is called once per frame
    void Update()
    {
        // Detect left-click (mouse button 0) and check if the object was clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits an object with the "fall object" tag
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Final Boss"))//Add more collider objects.
            {
                // Apply a swipe force to the object
                ApplySwipeForce(hit.collider.gameObject);
            }
        }
    }

    // Function to apply the swipe force and start despawning the object
    void ApplySwipeForce(GameObject finalBoss)
    {
        Rigidbody objectRb = finalBoss.GetComponent<Rigidbody>();

        if (objectRb != null)
        {
            // Apply a force upwards and in a random direction for a swiping effect
            Vector3 swipeDirection = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
            objectRb.AddForce(swipeDirection * swipeForce);

            // Start the despawn coroutine
            StartCoroutine(DespawnObject(finalBoss ));
        }
    }

    // Coroutine to despawn the object after a delay
    IEnumerator DespawnObject(GameObject finalBoss)
    {
        yield return new WaitForSeconds(despawnTime);

        // Destroy the object after the delay
        Destroy(finalBoss);

        SceneManager.LoadScene("WinCredit");
    }
}
