using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camrotation : MonoBehaviour
{
    bool movedown;
    bool moveup;
    public float movespeed;
    public Lightscript redlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (redlight.flashlight.color != Color.red)
        {

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
        if (redlight.flashlight.color == Color.red)
        {
            Vector2 playerDir = redlight.player.transform.position;
            float angle = Mathf.Atan2(playerDir.y - transform.position.y, playerDir.x - transform.position.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, (angle + 90f)));
            transform.transform.rotation = Quaternion.RotateTowards(transform.rotation, (targetRotation), 10000 * Time.deltaTime);

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
