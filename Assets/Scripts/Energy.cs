using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public static int currentEnergy;
    public static int neededEnergy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentEnergy++;
            Destroy(gameObject);
        }
    }
}
