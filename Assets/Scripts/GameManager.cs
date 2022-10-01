using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject problems;
    [SerializeField] private Timer timer;
    // Start is called before the first frame update
    private int problemAmt = 7;
    private float tenTimer = 10;
    void Start()
    {
        activateRandomProblems(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (tenTimer > 0)
        {
            tenTimer -= Time.deltaTime;
        }
        else
        {
            tenTimer = 10;
            activateRandomProblems(1);
        }
    }

    void activateRandomProblems(int amt)
    {
        for (int i = 0; i < amt; i++)
        {
            int randomChildIdx = Random.Range(0, problems.transform.childCount);
            Transform randomProblem = problems.transform.GetChild(randomChildIdx);
            randomProblem.gameObject.SetActive(true);
        }
    }
}
