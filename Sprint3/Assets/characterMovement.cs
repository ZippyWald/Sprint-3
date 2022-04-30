using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    //movement
    public float walkSpeed = 4;
    float speedLimiter = 0.6f;
    Vector2 movement;
    Rigidbody2D rb;
    //aim
    public Camera Cam;
    Vector2 mousePos;
    public float spinspeed;

    //animation
    Animator animator;
    string currentState;
    const string PLAYER_IDLE = "Idle";
    const string PLAYER_WALK = "Walk";

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos;
        rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);

        float angle = Mathf.Atan2(lookDir.y - rb.position.y, lookDir.x - rb.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, (angle+90f)));
        rb.transform.rotation = Quaternion.RotateTowards(transform.rotation, (targetRotation), spinspeed * Time.deltaTime);

        

        if (movement.x != 0 || movement.y != 0)
        {
            if (movement.x != 0 && movement.y != 0)
            {
                movement.x *= speedLimiter;
                movement.y *= speedLimiter;

            }

        }
        if (movement.x == 0 && movement.y == 0)
        {
            ChangeAnimationState(PLAYER_IDLE);
        }
        if (movement.x != 0 || movement.y != 0)
        {
            ChangeAnimationState(PLAYER_WALK);
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
