using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerstealthmeter : MonoBehaviour
{
    public Sprite[] eyestatus;
    public Lightscript visible;
    float eyebar;
    public Image eye;
    public Image eyemeter;
    public float eyemeterspeed;
    // Start is called before the first frame update
    void Start()
    {
        eyebar = 0;
    }

    // Update is called once per frame
    void Update()
    {
     if (visible.islooking == false)
            {
            eyebar -= eyemeterspeed * Time.deltaTime;
        }
        eyemeter.fillAmount = eyebar / 100;

        if (visible.islooking == true)
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
    }
    void Caught()
    {
        eyebar += eyemeterspeed * Time.deltaTime;
    }
}