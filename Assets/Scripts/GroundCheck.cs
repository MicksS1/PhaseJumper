using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PMove PMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            PMove.isGround = true;
            //Debug.Log(isGround);
            PMove.jumpCount = 1; // --> 2 jump
            PMove.dashCount = 1;
        }
        else
        {
            PMove.isGround = false;
            //Debug.Log(isGround);
        }

    }
}
