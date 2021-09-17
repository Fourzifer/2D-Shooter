using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteToWhite : MonoBehaviour
{
    private SpriteRenderer _myRenderer;
    private Shader _shaderGUItext;
    private Shader _shaderSpritesDefault;

    private void Start()
    {
        _myRenderer = gameObject.GetComponent<SpriteRenderer>();
        _shaderGUItext = Shader.Find("GUI/Text Shader");
        _shaderSpritesDefault = _myRenderer.material.shader;
    }

    void whiteSprite()
    {
        _myRenderer.material.shader = _shaderGUItext;
        _myRenderer.color = Color.white;
    }

    public void normalSprite()
    {
        _myRenderer.material.shader = _shaderSpritesDefault;
        _myRenderer.color = Color.white;
    }

    public IEnumerator FlashWhiteAndBack(int numFlashes = 1)
    {
        for (var i = 0; i < numFlashes; i++)
        {
            whiteSprite();
            yield return new WaitForSeconds(0.1f);
            normalSprite();
        }
    }
}