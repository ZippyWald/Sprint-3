using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class characterMovement : MonoBehaviour
{
    //movement
    public float walkSpeed = 4;
    float speedLimiter = 0.6f;
    public Vector2 movement;
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

    public bool canchange = false;
    bool showtextindoor;
    bool showintrotext;
    bool showdiamondtext;
    public bool showrespawntext;
    public TMPro.TextMeshProUGUI introtext;
    public TMPro.TextMeshProUGUI diamondtext;
    public TMPro.TextMeshProUGUI indoortext;
    public TMPro.TextMeshProUGUI respawntext;
    public float indoorcounter = 1.2f;
    public bool enterindoor =  false;
    public interactionscript diamondtextprompt;
    float diamondtextcounter = 2;
    public Transform playerposition;
    public float respawntimer = 0.5f;
    public bool respawn = false;
    public Playerstealthmeter eyebar;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);
        showintrotext = true;
        showtextindoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (respawn == true)
        {
            playerposition.position = new Vector3 (48,2,0);
            showrespawntext = true;
            eyebar.eyebar = 1f;
      


        }

        if (diamondtextprompt.havediamond == true)
        {
            showdiamondtext = true;
        }

        if (showrespawntext == true)
        {
            respawntext.enabled = true;
 
            respawn = false;
        }
        if (showrespawntext == false)
        {
            respawntext.enabled = false;
        }


        if (showintrotext == true)
        {
            introtext.enabled = true;
        }
        if (showintrotext == false)
        {
            introtext.enabled = false;
        }
        if (showdiamondtext == true)
        {
            diamondtext.enabled = true;
            diamondtextcounter -= Time.deltaTime;
        }
        if (diamondtextcounter <= 0)
        {
            showdiamondtext = false;
            diamondtextcounter = 0;

        }
        if (showdiamondtext == false)
        {
            diamondtext.enabled = false;
        }
        if (showtextindoor == true)
        {
            indoortext.enabled = true;
            indoorcounter -= Time.deltaTime;
        }
        if (showtextindoor == false)
        {
            indoortext.enabled = false;
        }
        if (indoorcounter <= 0)
        {
            showtextindoor = false;
            indoorcounter = -1;
            enterindoor = true;
        }



        if (gameObject.layer == 0)
        { 
        mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        }
        if (gameObject.layer == 6)
        {
            movement.x = 0;
            movement.y = 0;
        }
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "boxcamera")
        {
            canchange = true;
        }




    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "boxcamera")
        {
            canchange = false;
        }
        if (other.tag == "Start")
        {
            showintrotext = false;
        }
        if (other.tag == "Indoors" && diamondtextprompt.havediamond != true)
        {
             showtextindoor = true;

        }
        if (other.tag == "respawn")
        {
            showrespawntext = false;
        }


    }

}
