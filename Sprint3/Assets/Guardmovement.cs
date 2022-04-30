using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardmovement : MonoBehaviour
{
    //movement
    public float walkSpeed = 4;
    float speedLimiter = 0.6f;
    Vector2 movement;
    Rigidbody2D rb;


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

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        
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
