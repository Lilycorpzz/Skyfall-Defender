using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    // This method is called when the Retry button is pressed
    public void RetryGame()
    {
        // Reload the Game scene
        SceneManager.LoadScene("Game");
    }
}
