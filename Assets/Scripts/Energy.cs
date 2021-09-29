using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public static int currentEnergy;
    public static int neededEnergy;


    private EnergyBar energyBar;

    [SerializeField]
    public SpriteRenderer energySprite;
    public ParticleSystem particles;

    private int destroyDelay = 7;

    private void Start()
    {
        energyBar = GameObject.Find("EnergyBar").GetComponent<EnergyBar>();
        energyBar.SetMaxEnergy(neededEnergy);
        energyBar.SetEnergy(currentEnergy);

        StartCoroutine(Fade(5));

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

    IEnumerator Fade(float time)
    {
        yield return new WaitForSeconds(time);
        energySprite.color = new Color(1f, 1f, 1f, .5f);
        particles.startColor = new Color(1f, 1f, 1f, .3f);
    }
}
