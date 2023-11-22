using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        // Sets the cursor to visible
        Cursor.visible = true;
        
    }

    // Start is called before the first frame update
    public void PlayGame()
    {
        // Loads the next scene in the queue
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        // Quits the game
        Application.Quit();
    }
    public void OpenSettings()
    {
        // Loads the settings menu
    }
}
