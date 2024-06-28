using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject finishPanel;
    public bool isFinish;

    // Start is called before the first frame update
    void Start()
    {
        isFinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            Invoke("timeStop", 0.3f);
            isFinish = true;

            //AudioManager.instance.finishSlowMo();
        }
    }

    void timeStop()
    {
        Time.timeScale = 0f;
        finishPanel.SetActive(true);
    }
}
