using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayButton : MonoBehaviour
{
    // Reference to the "How to Play" instructions panel
    public GameObject howToPlayPanel;

    // Reference to the Main Menu panel
    public GameObject mainMenuPanel;

    // Function to toggle the visibility of the HowToPlay panel and hide the Main Menu
    public void ToggleHowToPlay()
    {
        if (howToPlayPanel != null && mainMenuPanel != null)
        {
            // Toggle the active state of the instructions panel
            bool isHowToPlayActive = howToPlayPanel.activeSelf;
            howToPlayPanel.SetActive(!isHowToPlayActive);

            // Hide the Main Menu when showing "How to Play", and show Main Menu when closing "How to Play"
            mainMenuPanel.SetActive(isHowToPlayActive);
        }
    }
}
