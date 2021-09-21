using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{


    public GameObject deathEffect;
    public GameObject playerShip;
    public GameObject lifeManager;

    public void PlayerDeath()
    {
        playerShip.SetActive(false);
        Energy.currentEnergy = 0;
        StartCoroutine(PlayerDeath(3));
    }
    IEnumerator PlayerDeath(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playerShip.SetActive(true);
    }
}



