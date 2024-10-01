using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipedObjectedController : MonoBehaviour
{
    public GameObject[] objectPrefabs;// Hold an array containing all the fall objects(Including pickups).
    public float swipeForce = 500f;
    // Time before the object despawns after being clicked
    public float despawnTime = 1f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the falling object
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Detect left-click (mouse button 0) and check if the object was clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits an object with the "fall object" tag
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("fall object"))//Add more collider objects.
            {
                // Apply a swipe force to the object
                ApplySwipeForce(hit.collider.gameObject);
            }
        }
    }

    // Function to apply the swipe force and start despawning the object
    void ApplySwipeForce(GameObject objectPrefabs)
    {
        Rigidbody objectRb = objectPrefabs.GetComponent<Rigidbody>();

        if (objectRb != null)
        {
            // Apply a force upwards and in a random direction for a swiping effect
            Vector3 swipeDirection = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
            objectRb.AddForce(swipeDirection * swipeForce);

            // Start the despawn coroutine
            StartCoroutine(DespawnObject(objectPrefabs));
        }
    }

    // Coroutine to despawn the object after a delay
    IEnumerator DespawnObject(GameObject objectPrefabs)
    {
        yield return new WaitForSeconds(despawnTime);

        // Destroy the object after the delay
        Destroy(objectPrefabs);
    }
}

