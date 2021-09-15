using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public SpriteRenderer m_SpriteRenderer;
    public Sprite newSprite;

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
                Energy.neededEnergy = 10;
                Debug.Log("Needed energy: " + (Energy.neededEnergy));
                break;
            case 1:
                Debug.Log("Level 2");
                Energy.neededEnergy = 10;
                Debug.Log("Needed energy: " + (Energy.neededEnergy));
                break;
            case 2:
                Debug.Log("Level 3");
                break;
            case 3:
                Debug.Log("Level 4");
                break;
            case 4:
                Debug.Log("Level 5");
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
            m_SpriteRenderer.color = Color.white;
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
    }
}
