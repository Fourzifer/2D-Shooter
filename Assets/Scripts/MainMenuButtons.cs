using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void NewGame()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MainMenu");
    }

    public void Continue()
    {
        if (PlayerPrefs.HasKey("LastCheckpointX") && PlayerPrefs.HasKey("LastCheckpointY"))
        {
            float xPos = PlayerPrefs.GetFloat("LastCheckpointX");
            float yPos = PlayerPrefs.GetFloat("LastCheckpointY");
        }
    }
}
