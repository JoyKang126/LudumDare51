using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemController : MonoBehaviour
{
    // Start is called before the first frame update
    private int hitCounter;

    private void OnEnable()
    {
        hitCounter = Random.Range(1,21);
    }

    public void decrementCounter() 
    {
        hitCounter = hitCounter - 1;
        Debug.Log(hitCounter);
        if(hitCounter == 0) 
        {
            gameObject.SetActive(false);
        }
    }
}
