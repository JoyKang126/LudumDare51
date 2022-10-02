using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private Transform problem;
    // Start is called before the first frame update
    public void activateProblem()
    {
        gameObject.SetActive(false);
        problem.gameObject.SetActive(true);
    }
}
