using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Behaviour : MonoBehaviour
{
    public GameObject Player;
    public Animator trapAnim;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Player.SetActive(false);
            //trapAnim.SetTrigger("Stop");
        }
    }
}
