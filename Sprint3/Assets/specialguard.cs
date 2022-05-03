using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialguard : MonoBehaviour
{
    public Guardmovement selfpatrol;
    public characterMovement playerscript;    // Start is called before the first frame update
    void Start()
    {
        selfpatrol = GetComponent<Guardmovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerscript.enterindoor == false)
        {
            selfpatrol.enabled = false;
        }
        if (playerscript.enterindoor == true)
        {
            selfpatrol.enabled = true;
        }
    }
}
