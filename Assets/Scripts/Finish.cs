using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Time.timeScale = 0.5f;
            Invoke("timeReset", 3f);
        }
    }

    void timeReset()
    {
        Time.timeScale = 1f;
    }
}
