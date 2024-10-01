using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    // Reference to the "How to Play" instructions panel
    public GameObject howToPlayPanel;

    // Reference to the Main Menu panel
    public GameObject mainMenuPanel;

    // Function to hide "How to Play" panel and show the Main Menu
    public void BackToMainMenu()
    {
        if (howToPlayPanel != null && mainMenuPanel != null)
        {
            // Hide the "How to Play" panel
            howToPlayPanel.SetActive(false);

            // Show the Main Menu panel
            mainMenuPanel.SetActive(true);
        }
    }
}
