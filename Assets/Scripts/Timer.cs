using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float time;
    public int minute;
    public int second;

    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        second = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        second = (int)time % 60;
        minute = (int)time / 60;

        timer.text = string.Format("{0:00}:{1:00}", minute, second);
    }

    public void resetTimer()
    {
        time = 0;
    }
}
