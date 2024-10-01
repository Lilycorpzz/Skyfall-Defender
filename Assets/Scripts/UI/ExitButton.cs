using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // This method can be called for exiting the game (optional)
    public void QuitGame()
    {
        // Exit the application
        Application.Quit();

        // If in the editor, log a message since Application.Quit() won't work
#if UNITY_EDITOR
        Debug.Log("Game has exited (Application.Quit() doesn't work in the editor).");
#endif
    }

}
