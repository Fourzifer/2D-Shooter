using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit");
    }
}
