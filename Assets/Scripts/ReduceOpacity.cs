using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceOpacity : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer building;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            building.color = new Color(1f, 1f, 1f, .5f);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            building.color = new Color(1f, 1f, 1f, 1f);
        }

    }
}
