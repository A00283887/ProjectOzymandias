using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMovement : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Demo");
    }

    public void tutorialMenu()
    {
        SceneManager.LoadScene("settingsMenu");
    }

    public void settingsMenu()
    {
        SceneManager.LoadScene("settingsMenu");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
