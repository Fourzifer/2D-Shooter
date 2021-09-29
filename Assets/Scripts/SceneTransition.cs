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

    [HideInInspector] public static int currentScene;

    public Animator transitionAnim;

    private bool soundplay = false;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        currentScene = SceneManager.GetActiveScene().buildIndex;

        print("Scene " + currentScene);

        switch (currentScene)
        {
            case 0:
                Energy.neededEnergy = 0;
                break;
            case 1:
                Energy.neededEnergy = 0;
                break;
            case 2:
                Energy.neededEnergy = 5;
                break;
            case 3:
                Energy.neededEnergy = 8;
                break;
            case 4:
                Energy.neededEnergy = 10;
                break;
            case 5:
                Energy.neededEnergy = 10;
                break;
            case 6:
                Energy.neededEnergy = 10;
                break;
            default:
                print("Unrecognised level");
                break;
        }

        print("Needed energy: " + (Energy.neededEnergy));
    }

    // Update is called once per frame
    void Update()
    {
        //Whirly effect
        transform.Rotate(0, 0, 30 * Time.deltaTime);

        if (Energy.currentEnergy >= Energy.neededEnergy)
        {
            m_SpriteRenderer.sprite = newSprite;

            if (!soundplay)
            {
                FindObjectOfType<AudioManager>().Play("Laser4");
                soundplay = true;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Energy.currentEnergy >= Energy.neededEnergy)
        {
            StartCoroutine(LoadScene());
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

    IEnumerator LoadScene()
    {
        Energy.currentEnergy = 0;
        print("Teleported");
        transitionAnim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
