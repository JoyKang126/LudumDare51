using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 180;
    public bool timerIsRunning = false;
    [SerializeField] TextMeshProUGUI timeText;

    private void Start()
    {
        timerIsRunning = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        
    }
    
    void DisplayTime(float timeToDisplay)
    {
        timeText.text = string.Format("{0:000}", timeToDisplay);
    }

    public float getTimeRemaining()
    {
        return timeRemaining;
    }
}
