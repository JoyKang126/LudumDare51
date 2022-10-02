using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemController : MonoBehaviour
{
    // Start is called before the first frame update
    private int hitCounter;
    [SerializeField] private HealthBarController healthBar;
    //[SerializeField] private Transform activateTrigger;
    
    private float dmgCounter = 1;
    private int priorityLvl = 1;
    public int savedHealth = 0;

    private void OnEnable()
    {
        //activateTrigger.gameObject.SetActive(false);
        savedHealth = 0;
        hitCounter = Random.Range(1,21);
        if (hitCounter >=15)
        {
            priorityLvl = 3;
        }
        else if (hitCounter >= 8)
        {
            priorityLvl = 2;
        }
        else
        {
            priorityLvl = 1;
        }
    }

    public void decrementCounter()
    {
        hitCounter = hitCounter - 1;
        Debug.Log("prob health" + hitCounter);
        if(hitCounter == 0) 
        {
            healthBar.AddHealth(savedHealth);
            //activateTrigger.gameObject.SetActive(true);
            gameObject.SetActive(false);   
        }
    }

    void Update()
    {
        if (dmgCounter > 0)
        {
            dmgCounter -= Time.deltaTime;
        }
        else
        {
            dmgCounter = 1;
            savedHealth += priorityLvl;
            healthBar.SubHealth(priorityLvl);
        }
    }
}
