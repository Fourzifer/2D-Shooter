using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public static int currentEnergy;
    public static int neededEnergy;

    private EnergyBar energyBar;

    private int destroyDelay = 5;

    private void Start()
    {
        energyBar = GameObject.Find("EnergyBar").GetComponent<EnergyBar>();
        energyBar.SetMaxEnergy(neededEnergy);
        energyBar.SetEnergy(currentEnergy);
        Destroy(gameObject, destroyDelay);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Pickup2");
            currentEnergy++;
            energyBar.SetEnergy(currentEnergy);
            Destroy(gameObject);
        }
    }
}
