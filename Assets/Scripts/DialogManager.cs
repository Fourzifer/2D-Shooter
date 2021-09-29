using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;

    public GameObject player;
    public GameObject arrow;
    public GameObject energy;
    public GameObject enemy;
    public GameObject portal;
    public GameObject imageThing;
    public GameObject smallArrow;
    public GameObject smallPortal;
    public GameObject imageThingEmpty;
    public GameObject obstacles;
    public GameObject health;


    private Queue<string> sentences;

    void Start()
    {
        GetComponent<TMPro.TextMeshPro>();
        sentences = new Queue<string>();
    }
    public void StartDialog(Dialog dialog)
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
        switch (sentences.Count)
        {
            case 7:
                if (player != null)
                {
                    player.SetActive(true);
                }
                break;
            case 5:
                if (enemy != null)
                {
                    player.SetActive(false);
                    energy.SetActive(true);
                    enemy.SetActive(true);
                    imageThingEmpty.SetActive(true);
                }
                break;
            case 4:
                if (portal != null)
                {
                    smallPortal.SetActive(true);
                    enemy.SetActive(false);
                    imageThingEmpty.SetActive(false);
                    imageThing.SetActive(true);
                }
                break;
            case 3:
                if (portal != null)
                {
                    imageThing.SetActive(false);
                    energy.SetActive(false);
                    portal.SetActive(true);
                    smallPortal.SetActive(true);
                    smallArrow.SetActive(true);
                }
                break;
            case 2:
                {
                    portal.SetActive(false);
                    smallArrow.SetActive(false);
                    smallPortal.SetActive(false);
                    obstacles.SetActive(true);
                }
                break;

            case 1:
                {
                    obstacles.SetActive(false);
                    health.SetActive(true);
                }
                break;
            case 0:
                {
                    health.SetActive(false);
                }
                break;
        }
    }
}
