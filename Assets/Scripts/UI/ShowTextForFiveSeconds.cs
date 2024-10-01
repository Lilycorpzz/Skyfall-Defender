using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTextForFiveSeconds : MonoBehaviour
{
    public TextMeshProUGUI uiText;  // Reference to the UI Text element
    public float displayDuration = 5f;  // Duration to show the text (default is 5 seconds)

    void Start()
    {
        // Start the coroutine to show the text for a limited time
        StartCoroutine(ShowAndHideText());
    }

    IEnumerator ShowAndHideText()
    {
        // Enable the UI text
        uiText.gameObject.SetActive(true);

        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        // Disable the UI text after the time is up
        uiText.gameObject.SetActive(false);
    }
}
