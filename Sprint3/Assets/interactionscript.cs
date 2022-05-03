using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class interactionscript : MonoBehaviour
{
    bool pickupdiamond;
    bool canHide;
    public SpriteRenderer playerrend;
    public ShadowCaster2D playershadow; 
    public Image diamondUI;
    public SpriteRenderer diamond;
    public CircleCollider2D diamondcol;
    bool isinside;
    float etimer;
    public bool havediamond = false;
    public characterMovement respawner;
    public TMPro.TextMeshProUGUI endtext;
    public TMPro.TextMeshProUGUI funnytext;
    float endtimer;
    float funnytimer = 0;
    bool reachend;
    public Playerstealthmeter stealthbar;



    // Start is called before the first frame update
    void Start()
    {
        pickupdiamond = false;
        canHide = false;
        endtext.enabled = false;
        funnytext.enabled = false;
        reachend = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (endtimer > 0)
        {
            endtimer -= Time.deltaTime;
        }
        if (funnytimer > 0)
        {
            funnytimer -= Time.deltaTime;
        }

        if (endtimer <= 0 && reachend == true && funnytimer == 0 && funnytext.enabled == false)
        {
            endtimer = 0;
            funnytimer = 1.5f;
            funnytext.enabled = true;
            endtext.enabled = false;

        }

        if (funnytimer <= 0 && funnytext.enabled == true)
        {
            Debug.Log("end");
            Application.Quit();
           

        }
        if (stealthbar.eyebar >= 109f)
        {
            diamondUI.enabled = false;
            diamond.enabled = true;
            diamondcol.enabled = true;
            havediamond = false;
        }
        if (etimer > 0)
        {
            etimer -= Time.deltaTime;
        }
     
        if(Input.GetKeyDown(KeyCode.E))
         {
            if (pickupdiamond == true)
            {
                diamondUI.enabled = true;
                diamond.enabled = false;
                diamondcol.enabled = false;
                havediamond = true;
            }
            if (canHide == true)
            {
                Hide();
            }
            if (isinside == true && etimer <= 0)
            {
                leavehiding();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Closet")
        {
            canHide = true;
        }
        if (other.tag == "Diamond")
        {
            pickupdiamond = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Diamond")
        {
            pickupdiamond = false;
        }
        if (other.tag == "Closet")
        {
            canHide = false;
        }
        if (other.tag == "end" && havediamond == true)
        {
            endtext.enabled = true;
            endtimer = 5f;
            reachend = true;
        }
    }
    void Hide()
    {
        isinside = true;
        gameObject.layer = 6;
        playerrend.enabled = false;
        playershadow.enabled = false;

        
        etimer = 1;
    }

    void leavehiding()
    {
        isinside = false;
        gameObject.layer = 0;
        playerrend.enabled = true;
        playershadow.enabled = true;


    }

}
