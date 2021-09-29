using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;


    private Queue<string> sentences;

    void Start()
    {
        GetComponent<TMPro.TextMeshPro>();
        sentences = new Queue<string>();
    }
    public void StartDialog (Dialog dialog)
    {

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    void EndDialog()
    {
        SceneManager.LoadScene("LevelOne");
    }

    void Update()
    {
        
    }
}
