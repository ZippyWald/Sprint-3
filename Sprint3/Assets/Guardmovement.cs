using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardmovement : MonoBehaviour
{
    //movement
    Rigidbody2D rb;


    //animation
    Animator animator;
    string currentState;
    const string PLAYER_IDLE = "guardidle";
    const string PLAYER_WALK = "guardwalk";
    //patrol
    public Transform[] waypoints;
    int current = 0;
    public float speed;
    float WPradius = 0.3f;
    float patroltime = 0;
    public float spinspeed = 80;
    public Lightscript redlight;
    public float patroltimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
 

    }

    // Update is called once per frame
    void Update()
    {

        if (patroltime > 0)
        {
            patroltime -= 1 * Time.deltaTime;
        }

        // movement
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            patroltime = patroltimer;
            current += 1;
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            
        }
        if (patroltime <= 0 && redlight.flashlight.color != Color.red)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }
    }
    private void FixedUpdate()
    {
        if (redlight.flashlight.color != Color.red)
        {
            Vector2 lookDir = waypoints[current].transform.position;
            float angle = Mathf.Atan2(lookDir.y - rb.position.y, lookDir.x - rb.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, (angle + 90f)));
            rb.transform.rotation = Quaternion.RotateTowards(transform.rotation, (targetRotation), spinspeed * Time.deltaTime);

            if (patroltime > 0)
            {
                ChangeAnimationState(PLAYER_IDLE);
            }
            if (patroltime <= 0)
            {
                ChangeAnimationState(PLAYER_WALK);
            }
        }
        if (redlight.flashlight.color == Color.red)
        {
            
            Vector2 playerDir = redlight.player.transform.position;
            float angle = Mathf.Atan2(playerDir.y - rb.position.y, playerDir.x - rb.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, (angle + 90f)));
            rb.transform.rotation = Quaternion.RotateTowards(transform.rotation, (targetRotation), 10000 * Time.deltaTime);

        }
        
    }
    void ChangeAnimationState(string newState)

    {
        // Stop animation from interrupting itself
        if (currentState == newState) return;


        //Play new animation
        animator.Play(newState);

        //Update current state
        currentState = newState;
    }
}
