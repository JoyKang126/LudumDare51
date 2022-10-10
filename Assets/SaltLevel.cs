using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaltLevel : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    [SerializeField] private Transform salt;

    void Update()
    {
        if (slider.value>=66)
        {
            salt.GetChild(0).gameObject.SetActive(false);
            salt.GetChild(1).gameObject.SetActive(false);
            salt.GetChild(2).gameObject.SetActive(true);
        }
        else if (slider.value >= 33)
        {
            salt.GetChild(0).gameObject.SetActive(false);
            salt.GetChild(1).gameObject.SetActive(true);
            salt.GetChild(2).gameObject.SetActive(false);
        }
        else if (slider.value >= 1)
        {
            salt.GetChild(0).gameObject.SetActive(true);
            salt.GetChild(1).gameObject.SetActive(false);
            salt.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            salt.GetChild(0).gameObject.SetActive(false);
            salt.GetChild(1).gameObject.SetActive(false);
            salt.GetChild(2).gameObject.SetActive(false);
        }
    }

    public void SetMaxSalt(int salt)
    {
        slider.maxValue = salt;
        slider.value = 99;
    }
    // Start is called before the first frame update
    public void SetSalt(float salt)
    {
        slider.value = salt;
    }

    public void SubSalt(int salt)
    {
        slider.value -= salt;
    }

    public void AddSalt(int salt)
    {
        slider.value += salt;
    }
}
