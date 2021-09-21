using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lives : MonoBehaviour
{
    public int life;
    public int lifeAmount;

    public  Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void LoseLife()
    {
            lifeAmount--;
            hearts[lifeAmount].enabled = false;
    }

    public void GameOver()
    {
        if (lifeAmount == 0)
        {
            Debug.Log("Game lost");
        }
    }

}
