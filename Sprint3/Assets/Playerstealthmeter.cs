using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using TMPro;

public class Playerstealthmeter : MonoBehaviour
{
    public characterMovement playerrespawn;
    public Sprite[] eyestatus;
    public bool islooking;
    public float eyebar;
    public Image eye;
    public Image eyemeter;
    public float eyemeterspeed;
    public float eyemeterspeeddeplete = 30;
    public Light2D globallight;
    public TMPro.TextMeshProUGUI hardmode;
    public TMPro.TextMeshProUGUI easymode;
    bool easymodeenabled = true;

    float textimer;

    // Start is called before the first frame update
    void Start()
    {
        eyebar = 0;
        easymodeenabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && easymodeenabled == true && textimer == 0 )
        {
            hardmode.enabled = true;
            textimer = 2;
            eyemeterspeed = 60;
            easymodeenabled = false;

        }
        if (Input.GetKeyDown(KeyCode.H) && easymodeenabled == false && textimer == 0)
        {
            easymode.enabled = true;
            textimer = 2;
            eyemeterspeed = 30;
            easymodeenabled = true;

        }
        if (textimer > 0)
        {
            textimer -= Time.deltaTime;
        }
        if (textimer <= 0)
        {
            textimer = 0;
            hardmode.enabled = false;
            easymode.enabled = false;
        }
       
     if (islooking == false)
        {
            if (eyebar < 0)
            {
                eyebar = 0;
            }
            if (eyebar >= 0)
            {
                eyebar -= eyemeterspeeddeplete * Time.deltaTime;
            }
            

        }
        eyemeter.fillAmount = eyebar / 100;

        if (islooking == true)
        {
            Caught();
        }
        if (eyebar >= 0 && eyebar < 10)
        {
            eye.sprite = eyestatus[0];
        }
        if (eyebar > 10 && eyebar < 20)
        {
            eye.sprite = eyestatus[1];
        }
        if (eyebar > 20 && eyebar < 30)
        {
            eye.sprite = eyestatus[2];
        }
        if (eyebar > 30 && eyebar < 40)
        {
            eye.sprite = eyestatus[3];
        }
        if (eyebar > 40 && eyebar < 50)
        {
            eye.sprite = eyestatus[4];
        }
        if (eyebar > 50 && eyebar < 60)
        {
            eye.sprite = eyestatus[5];
        }
        if (eyebar > 60 && eyebar < 70)
        {
            eye.sprite = eyestatus[6];
            eyemeter.color = Color.red;
        }
        if (eyebar > 70 && eyebar < 85)
        {
            eye.sprite = eyestatus[7];
        }
        if (eyebar > 85 && eyebar < 99)
        {
            eye.sprite = eyestatus[8];
            
        }
        if (eyebar >=  100)
        {
            eye.sprite = eyestatus[9];
            
        }
        if (eyebar >= 100)
        {
            globallight.color = Color.red;
        }
        if (eyebar < 100)
        {
            globallight.color = Color.white;
        }
        if (eyebar < 60)
        {
            eyemeter.color = Color.white;
        }
    }
    void Caught()
    {
        if (eyebar < 110)
        {
            eyebar += eyemeterspeed * Time.deltaTime;
        }
        if (eyebar >= 110)
        {
            eyebar = 110;
            playerrespawn.respawn = true;



        }
        
    }
}
