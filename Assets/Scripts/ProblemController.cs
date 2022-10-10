using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProblemController : MonoBehaviour
{
    // Start is called before the first frame update
    private int hitCounter;
    [SerializeField] private HealthBarController healthBar;
    [SerializeField] private Transform counterpart;
    [SerializeField] private TMP_Text counterText;
    [SerializeField] private ScoreScriptableObject score;
    
    public bool level3 = false;
    private float dmgCounter = 1;
    private float priorityLvl = 1f;
    public float savedHealth = 0;

    private void OnEnable()
    {
        level3 = false;
        counterpart.gameObject.SetActive(false);
        savedHealth = 0;
        hitCounter = Random.Range(1,21);
        if (hitCounter >=16)
        {
            priorityLvl = 3;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (hitCounter >= 8)
        {
            priorityLvl = 2;
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            priorityLvl = 1;
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void decrementCounter()
    {
        hitCounter = hitCounter - 1;
        if(hitCounter == 0) 
        {
            AddToScore(gameObject.name);
            healthBar.AddHealth(savedHealth);
            counterpart.gameObject.SetActive(true);
            gameObject.SetActive(false);   
        }
    }

    void Update()
    {
        counterText.text = hitCounter.ToString();

        if (dmgCounter > 0)
        {
            dmgCounter -= Time.deltaTime;
        }
        else
        {
            dmgCounter = 1;
            if (!level3)
            {
                savedHealth += priorityLvl;
                healthBar.SubHealth(priorityLvl);
            }
            else
            {
                savedHealth += priorityLvl/1.25f;
                healthBar.SubHealth(priorityLvl/1.25f);
            }
            
        }
    }

    private void AddToScore(string name)
    {
        switch(name)
        {
            case "ghost tub":
                score.tubs++;
                break;
            case "ghost bed":
                score.beds++;
                break;
            case "ghost window":
                score.windows++;
                break;
            case "ghost door":
                score.doors++;
                break;
            case "ghost tv":
                score.tvs++;
                break;
            case "ghost light":
                score.lights++;
                break;
            case "ghost cake":
                score.cakes++;
                break;
        }
    }
}
