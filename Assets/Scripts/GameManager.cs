using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject playerShip;
    public Lives lifeManager;
    public HealthBar healthBar;

    [SerializeField]
    private EnergyBar _energyBar;

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
            healthBar.SetHealth(player.maxHealth);
        }
        else
        {
            yield return new WaitForSeconds(time);
            Energy.currentEnergy = 0;

            playerShip.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            if (_energyBar == null)
                yield return null;

            _energyBar.SetEnergy(Energy.currentEnergy);

        }
    }
}



