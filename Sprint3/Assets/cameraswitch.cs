using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraswitch : MonoBehaviour
{
    public Transform playerpos;
    public Cinemachine.CinemachineConfiner2D confiner;
    public PolygonCollider2D confinerout;
    public PolygonCollider2D confinerin;
    public characterMovement playercollision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerpos.position.x <= 24 && playerpos.position.y >= 4f && playerpos.position.y <= 6f)
        {
            confiner.m_BoundingShape2D = confinerin;
        }
        if (playerpos.position.x > 24 && playerpos.position.y <= 2f)
        {
            confiner.m_BoundingShape2D = confinerout;
        }
    }
    
}
