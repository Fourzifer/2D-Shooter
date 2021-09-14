using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    private void Start()
    {
        slider.value = 0;
    }

    public void SetMaxEnergy(int energy)
    {
        slider.maxValue = energy;
        slider.value = energy;
    }
    public void SetEnergy(int energy)
    {
        slider.value = energy;
    }
}
