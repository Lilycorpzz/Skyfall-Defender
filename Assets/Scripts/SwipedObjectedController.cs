using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipedObjectedController : MonoBehaviour
{
    public float swipeForce = 1000f;
    public float despawnTime = 2f;

    void Update()
    {
        // Detect left-click (mouse button 0) and check if the object was clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits an object with the appropriate tags
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.CompareTag("fall object") || hitObject.CompareTag("BasketBall") || hitObject.CompareTag("BaseBall"))
                {
                    // Apply a swipe force to the object
                    ApplySwipeForce(hitObject);

                    if (hitObject.CompareTag("BasketBall"))
                    {
                        // Add score when a "fall object" is swiped
                        ScoreManager.Instance.AddScore(5); // Add 1 points for each swiped object
                    }
                    else if (hitObject.CompareTag("BaseBall"))
                    {
                        // Add score when a "fall object" is swiped
                        ScoreManager.Instance.AddScore(10); // Add 1 points for each swiped object
                    }
                    else
                    {
                        // Add score when a "fall object" is swiped
                        ScoreManager.Instance.AddScore(1); // Add 1 points for each swiped object
                    }
                 

                    // Destroy the fall object instantly
                   // Destroy(hitObject);

                }
                else if (hitObject.CompareTag("HealthPickup"))
                {
                    hitObject.GetComponent<HealthBoostPickup>().OnHitByRaycast(GameObject.FindWithTag("Player"));
                }
                else if (hitObject.CompareTag("ShieldPickup"))
                {
                    hitObject.GetComponent<UmbrellaPickup>().OnHitByRaycast(GameObject.FindWithTag("Player"));
                }
                else if (hitObject.CompareTag("SlowTimePickup"))
                {
                    hitObject.GetComponent<PowerUpSlowTime>().OnHitByRaycast();
                }
            }
        }
    }

    // Function to apply the swipe force and start despawning the object
    public void ApplySwipeForce(GameObject objectPrefab)
    {
        Rigidbody objectRb = objectPrefab.GetComponent<Rigidbody>();

        if (objectRb != null)
        {
            // Apply a force upwards and in a random direction for a swiping effect
            Vector3 swipeDirection = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
            objectRb.AddForce(swipeDirection * swipeForce);

            // Start the despawn coroutine
            StartCoroutine(DespawnObject(objectPrefab));
        }
        // Coroutine to despawn the object after a delay
        IEnumerator DespawnObject(GameObject objectPrefab)
        {
            yield return new WaitForSeconds(despawnTime);
            Destroy(objectPrefab);
        }
    }

    
}

