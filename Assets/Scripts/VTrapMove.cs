using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class VTrapMove : MonoBehaviour
{
    public GameObject VTrap;
    public float distance;
    public float speed;
    private float originalPos;
    private float t;
    public float test;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position.x;
        t = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        test = Mathf.Sin(t) * distance;
        VTrap.transform.position = new Vector2(originalPos + test, transform.position.y);
        t = t + speed * Time.deltaTime;
    }
}
