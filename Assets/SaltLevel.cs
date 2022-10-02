using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaltLevel : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxSalt(int salt)
    {
        slider.maxValue = salt;
        slider.value = 100;
        fill.color = gradient.Evaluate(0f);
    }
    // Start is called before the first frame update
    public void SetSalt(float salt)
    {
        slider.value = salt;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SubSalt(int salt)
    {
        slider.value -= salt;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void AddSalt(int salt)
    {
        slider.value += salt;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
