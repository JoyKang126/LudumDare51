using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = 100;
        fill.color = gradient.Evaluate(0f);
    }
    // Start is called before the first frame update
    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SubHealth(int health)
    {
        slider.value -= health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void AddHealth(int health)
    {
        slider.value += health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
