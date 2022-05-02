using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lightscript : MonoBehaviour
{
    public Light2D flashlight;
    public bool islooking;
    public GameObject player;
    public float flashlightlength;
    public bool eyesight;
    public Playerstealthmeter visibility;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (eyesight == true)
        {
          
            RaycastHit2D findplayer = Physics2D.Raycast(transform.position, player.transform.position - transform.position, flashlightlength);
            if (findplayer)
            {
                Debug.Log("hit  " + findplayer.collider.name);
                if (findplayer.collider.tag == "Player")
                {
                    flashlight.color = Color.red;
                    visibility.islooking = true;

                    
                }

                if (findplayer.collider.tag != "Player")
                {
                    flashlight.color = Color.white;
                    visibility.islooking = false;
                }

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            eyesight = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            eyesight = false;
            flashlight.color = Color.white;
            visibility.islooking = false;


        }
    }

}
