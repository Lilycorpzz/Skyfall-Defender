using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // This method can be called for exiting the game (optional)
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}
