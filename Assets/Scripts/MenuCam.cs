using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCam : MonoBehaviour
{
    public Rigidbody2D camRB;
    [Range(0f, 10f)] public float camSpeed;

    // Start is called before the first frame update
    void Start()
    {

        camRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        camRB.velocity = new Vector2(camSpeed, 0f);
    }
}
