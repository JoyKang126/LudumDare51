using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform problems;
    [SerializeField] private Timer timer;
    [SerializeField] private HealthBarController healthBar;
    [SerializeField] private SaltLevel saltBar;
    [SerializeField] private Transform ghost;
    [SerializeField] private PlayerMovement player;
    // Start is called before the first frame update

    private float tenTimer = 10;
    private float oneTimer = 1;
    private float diffLvl = 1;
    void Start()
    {
        activateRandomProblems(Mathf.FloorToInt(diffLvl));
        healthBar.SetMaxHealth(100);
        saltBar.SetMaxSalt(100);
    }

    // Update is called once per frame
    void Update()
    {

        if(saltBar.slider.value == saltBar.slider.maxValue)
        {
            if (ghost.gameObject.activeSelf)
            {
                ghost.gameObject.SetActive(false);
            }
        }

        if (ghost.gameObject.activeSelf)
        {
            player.SetPlayerSpeed(15f);
        }
        else
        {
            player.SetPlayerSpeed(30f);
        }

        if (tenTimer > 0)
        {
            tenTimer -= Time.deltaTime;
        }
        else
        {
            tenTimer = 10;
            
            if (diffLvl >= 2)
                diffLvl += 0.15f;
            else if (diffLvl >= 1)
                diffLvl += 0.3f;
            activateRandomProblems(Mathf.FloorToInt(diffLvl));
            if(!ghost.gameObject.activeSelf)
                MaybeSpawnGhost();
        }

        if (oneTimer > 0)
        {
            oneTimer -= Time.deltaTime;
        }
        else
        {
            oneTimer = 1;
            saltBar.SubSalt(3);
        }
    }

    void activateRandomProblems(int amt)
    {
        List<int> inactiveList = new List<int>();
        foreach(Transform child in problems)
        {
            if(!child.gameObject.activeSelf)
            {
                inactiveList.Add(child.GetSiblingIndex());
            }
        }
        int true_amt;
        if (inactiveList.Count <= amt)
        {
            true_amt = inactiveList.Count;
        }
        else
        {
            true_amt = amt;
        }
        HashSet<int> alreadyChosen = new HashSet<int>();
        for (int i = 0; i < true_amt; i++)
        {
            int randomChildIdx = Random.Range(0, inactiveList.Count);
            while (alreadyChosen.Contains(randomChildIdx))
                randomChildIdx = Random.Range(0, inactiveList.Count);
            alreadyChosen.Add(randomChildIdx);
            Transform randomProblem = problems.transform.GetChild(inactiveList[randomChildIdx]);
            randomProblem.gameObject.SetActive(true);
        }
    }

    void MaybeSpawnGhost()
    {
        int diceRoll = Random.Range(1, 100);
        Debug.Log(diceRoll);
        if (diceRoll > saltBar.slider.value)
        {
            ghost.position = new Vector3(-7f, -3f, 0);
            ghost.gameObject.SetActive(true);
        }
            
    }
}
