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
        SceneManager.LoadScene("Main Menu");
    }

    public void PressNo()
    {
        Destroy(CloneMenu);
    }
}
