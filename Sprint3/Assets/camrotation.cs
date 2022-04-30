using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camrotation : MonoBehaviour
{
    bool movedown;
    bool moveup;
    public float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("rotatio " + transform.localRotation.eulerAngles.z);
        if (transform.localRotation.eulerAngles.z >= 119f)
        {
            movedown = true;
            moveup = false;
        }
        if (transform.localRotation.eulerAngles.z <= 61f)
        {
            movedown = false;
            moveup = true;
        }
    }
    private void FixedUpdate()
    {
        if (movedown ==  true)
        {
            transform.Rotate(new Vector3(0, 0, -movespeed * Time.deltaTime));
        }
        if (moveup == true)
        {
            transform.Rotate(new Vector3(0, 0, movespeed * Time.deltaTime));
        }
    }
}
