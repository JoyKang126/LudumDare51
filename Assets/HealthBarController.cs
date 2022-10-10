using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    public Slider slider;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = 100;
    }
    // Start is called before the first frame update
    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void SubHealth(float health)
    {
        slider.value -= health;
    }

    public void AddHealth(float health)
    {
        slider.value += health;
    }
}
