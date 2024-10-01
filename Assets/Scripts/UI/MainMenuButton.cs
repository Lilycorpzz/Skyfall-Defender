using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    // This method is called when the Main Menu button is pressed
    public void GoToMainMenu()
    {
        // Load the MainMenu scene
        SceneManager.LoadScene("MainMenu");
    }
}
