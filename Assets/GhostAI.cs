using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GhostAI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource dieSound;
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;

    //private int ghostHealth = 10;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    bool frozen = false;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    public void DeathAnim()
    {
        StartCoroutine(DieCo());
    }
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("trigger"))
        {
           other.gameObject.GetComponent<Trigger>().activateProblem();
        }
    }

    public void decrementHealth()
    {
        ghostHealth = ghostHealth - 1;
        Debug.Log("ghost health" + ghostHealth);
        if(ghostHealth == 0)
        {
            gameObject.SetActive(false);
        }
    }
    */
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!frozen)
        {
            if (path == null)
                return;
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }
            
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
                currentWaypoint++;

            if(rb.velocity.x >= 0.01f && force.x >0f)
            {
                enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (rb.velocity.x <= -0.01f && force.x < 0f)
            {
                enemyGFX.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    private IEnumerator DieCo()
    {
        dieSound.Play();
        frozen = true;
        animator.SetBool("SaltFull", true);
        yield return null;
        yield return new WaitForSeconds(1.3f);
        gameObject.SetActive(false);
        frozen = false;
    }
}
