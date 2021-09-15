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


    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        message = cloneMessage;
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
        else
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
