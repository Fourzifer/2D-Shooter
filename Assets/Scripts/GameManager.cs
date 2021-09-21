using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField]
    //private Vector2 lastCheckpointPos;

    //public Vector2 LastCheckpointPos
    //{
    //    get { return lastCheckpointPos; }
    //    set { lastCheckpointPos = value;  }
    //}

    //private string lastCheckpointName;

    //public string LastCheckpointName
    //{
    //    get { return lastCheckpointName; }
    //    set { lastCheckpointName = value;
    //        Debug.Log("Checkpoint recorded: " + value);
    //            }
    //}

    //private void Start()
    //{
    //    if (PlayerPrefs.HasKey("LastCheckpointX") && PlayerPrefs.HasKey("LastCheckpointY"))
    //    {
    //        float xPos = PlayerPrefs.GetFloat("LastCheckpointX");
    //        float yPos = PlayerPrefs.GetFloat("LastCheckpointY");
    //    }
    //}

    //private void OnApplicationQuit()
    //{   
    //    if (lastCheckpointPos.x != 0f && lastCheckpointPos.y != 0f)
    //    PlayerPrefs.SetFloat("LastCheckpointX", lastCheckpointPos.x);
    //    PlayerPrefs.SetFloat("LastCheckpointY", lastCheckpointPos.y);
    //}

    public GameObject deathEffect;
    public GameObject playerShip;

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



