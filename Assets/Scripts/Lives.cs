using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lives : MonoBehaviour
{
    public int life;
    [SerializeField]
    public int lifeAmount;

    public  Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void LoseLife()
    {
            hearts[lifeAmount].enabled = false;
    }
}
