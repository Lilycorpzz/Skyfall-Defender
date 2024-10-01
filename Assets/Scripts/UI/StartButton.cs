using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // This method is called when the Start button is pressed
    public void StartGame()
    {
        // Load the Game scene (make sure your Game scene is named "Game" in the build settings)
        SceneManager.LoadScene("Game");
    }
}
