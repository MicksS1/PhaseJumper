using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP_Behaviour : MonoBehaviour
{
    public PlatformEffector2D plat;

    // Start is called before the first frame update
    void Start()
    {
        plat = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            plat.rotationalOffset = 180;
            Invoke("platReset", 0.3f);
        }

        //else if (Input.GetKeyUp(KeyCode.S))
        //    plat.rotationalOffset = 0;
    }

    private void platReset()
    {
        plat.rotationalOffset = 0;
    }
}
