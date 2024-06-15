using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delete", 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
