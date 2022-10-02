using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SaltLevel saltBar;
    public CharacterController2D controller;
    public Animator animator;
    public KeyCode fix;
    public KeyCode salt;
    float horizontalMove = 0f;
    bool jump = false;
    public float runSpeed = 30f;
    public Collider2D currentInterObj = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(fix))
        {
            StartCoroutine(FixCo());
            
            if (currentInterObj != null && currentInterObj.CompareTag ("problem")) 
            {
                currentInterObj.gameObject.GetComponent<ProblemController>().decrementCounter();
            }
        }
        if (Input.GetKeyDown(salt))
        {
            if (currentInterObj != null && currentInterObj.CompareTag ("salt")) 
            {
                saltBar.AddSalt(10);
            }
        }
    }
    
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void SetPlayerSpeed(float speed)
    {
        runSpeed = speed;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentInterObj = other;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        currentInterObj = null;
    }

    private IEnumerator FixCo()
    {
        animator.SetBool("IsFixing", true);
        yield return null;
        animator.SetBool("IsFixing", false);
        yield return new WaitForSeconds(.3f);
    }
}