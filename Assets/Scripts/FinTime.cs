using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinTime : MonoBehaviour
{
    public Timer timeUI;
    public TMP_Text finTimeTxt;

    // Start is called before the first frame update
    void Start()
    {
        timeUI = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        finTimeTxt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        finTimeTxt.text = string.Format("{0:00}:{1:00}", timeUI.minute, timeUI.second);
    }
}
