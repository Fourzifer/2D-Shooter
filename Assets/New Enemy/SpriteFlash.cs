using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1, 0.5f, 0, 0.5f);
        Debug.Log("Sprite Flashed");
    }

    public static void Flash()
    {
        //sprite.color = new Color(1, 0, 0, 1);
        Debug.Log("Sprite Flashed");
    }

}
