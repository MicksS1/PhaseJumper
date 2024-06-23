using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class cobacoba : MonoBehaviour
{
    public EventTrigger qq;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void modar ()
    {
        Debug.Log("apalah");
    }

    public void OnEnable()
    {
        qq.OnTrigger.AddListener(modar);
    }
}
