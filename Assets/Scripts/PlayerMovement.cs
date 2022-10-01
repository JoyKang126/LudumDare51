using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public KeyCode fix;
    float horizontalMove = 0f;
    bool jump = false;
    public float runSpeed = 40f;
    public GameObject currentInterObj = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetKeyDown(fix))
        {
            if (currentInterObj != null) 
            {
                currentInterObj.GetComponent<ProblemController>().decrementCounter();
            }
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentInterObj = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        currentInterObj = null;
    }
}