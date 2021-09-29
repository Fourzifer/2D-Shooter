using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject Menu;
    public GameObject CloneMenu;

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PressNo()
    {
        player.isPaused = false;
        Time.timeScale = 1;
        Destroy(CloneMenu);
    }
}
