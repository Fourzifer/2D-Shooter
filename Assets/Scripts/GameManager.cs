using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{


    public GameObject deathEffect;
    public GameObject playerShip;
    public Lives lifeManager;
    [SerializeField]

    public void PlayerDeath()
    {
        playerShip.SetActive(false);
        StartCoroutine(PlayerDeath(3));
    }
    IEnumerator PlayerDeath(float time)
    {
        if (lifeManager.lifeAmount > 0)
        {
            yield return new WaitForSeconds(time);
            lifeManager.LoseLife();
            playerShip.SetActive(true);
            playerShip.GetComponent<player>().currentHealth = player.maxHealth;
        }
        else
        {
            yield return new WaitForSeconds(time);
            playerShip.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}



