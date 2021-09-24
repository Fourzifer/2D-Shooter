using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Flash()
    {
        StartCoroutine(FlashForSeconds());
    }

    IEnumerator FlashForSeconds()
    {
        sprite.color = new Color(1, 0.5f, 0, 0f);
        Debug.Log("Sprite Flashed");

        yield return new WaitForSeconds(0.1f);

        //sr.color = new Color(1, 0.5f, 0, 1f);

        //sprite.color = sprite;

    }
}
