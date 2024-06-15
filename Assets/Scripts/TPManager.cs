using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPManager : MonoBehaviour
{
    public GameObject TP;
    public PMove PMove;
    public GameObject Player;
    //private bool hasRun = false;

    // Start is called before the first frame update
    void Start()
    {
        //PMove = FindObjectOfType<PMove>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && PMove.dashCount > 0 && PMove.CD == false)
        {
            Instantiate(TP, Player.transform.position, Player.transform.rotation);
        }
    }
}
