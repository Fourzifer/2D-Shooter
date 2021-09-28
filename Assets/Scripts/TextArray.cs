using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextArray : MonoBehaviour
{
    public Image[] tutorialText;
    public int currentText;
    public Image imagy;


    public void Start()
    {

    }
    public void Update()
    {
        if (Input.GetButtonDown("Enter"))
        {
            tutorialText[currentText].enabled = true;
                currentText++;
        }
    }
}
