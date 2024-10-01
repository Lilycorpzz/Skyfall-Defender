using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Reference to the pause menu UI panel
    private bool isPaused = false;

    // Function to handle the pause and resume logic
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame(); // If the game is paused, resume it
        }
        else
        {
            Pause(); // If the game is running, pause it
        }
    }

    // Function to pause the game
    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game by setting time scale to 0
        pauseMenuPanel.SetActive(true); // Show the pause menu
    }

    // Function to resume the game
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game by setting time scale back to 1
        pauseMenuPanel.SetActive(false); // Hide the pause menu
    }
}
