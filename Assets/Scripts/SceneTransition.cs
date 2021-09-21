using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public SpriteRenderer m_SpriteRenderer;
    public Sprite newSprite;
    public GameObject message;
    public GameObject cloneMessage;

    private int currentScene;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        currentScene = SceneManager.GetActiveScene().buildIndex;

        switch (currentScene)
        {
            case 0:
                Debug.Log("Level 1");
                Energy.neededEnergy = 0;
                Debug.Log("Needed energy: " + (Energy.neededEnergy));
                break;
            case 1:
                Debug.Log("Level 2");
                Energy.neededEnergy = 10;
                Debug.Log("Needed energy: " + (Energy.neededEnergy));
                break;
            case 2:
                Energy.neededEnergy = 15;
                Debug.Log("Needed energy: " + (Energy.neededEnergy));
                Debug.Log("Level 3");

                break;
            case 3:
                Energy.neededEnergy = 20;
                Debug.Log("Needed energy: " + (Energy.neededEnergy));
                Debug.Log("Level 4");
                break;
            case 4:
                Energy.neededEnergy = 25;
                Debug.Log("Needed energy: " + (Energy.neededEnergy));
                Debug.Log("Level 5");
                break;
            case 5:
                Energy.neededEnergy = 30;
                Debug.Log("Needed energy: " + (Energy.neededEnergy));
                break;
            default:
                print("Level has no max energy");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Whirly effect
        transform.Rotate(0, 0, 30 * Time.deltaTime);

        //if (Energy.currentEnergy == 3)
        if (Energy.currentEnergy >= Energy.neededEnergy)
        {
            m_SpriteRenderer.sprite = newSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("Player") && Energy.currentEnergy >= 3)
        if (other.CompareTag("Player") && Energy.currentEnergy >= Energy.neededEnergy)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Energy.currentEnergy = 0;
            Debug.Log("Teleported");
        }
        else if (other.CompareTag("Player"))
        {
            cloneMessage = (GameObject)Instantiate(message);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(cloneMessage);
        }
    }
}
