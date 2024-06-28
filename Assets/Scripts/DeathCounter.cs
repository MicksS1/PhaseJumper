using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    public TMP_Text count;
    public PMove PMove;

    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        PMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("mati");
        AddDeath();
    }

    public void AddDeath()
    {
        count.text = PMove.deaths.ToString();
        //AudioManager.instance.playSfx("Dead");
    }
}
