using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMove : MonoBehaviour
{
    public RectTransform move;
    public float distance;
    public float test;
    private float t;
    private float originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = move.localPosition.y;
        t = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        test = Mathf.Sin(t) * distance;
        move.localPosition = new Vector3(move.localPosition.y, originalPos + test, move.localPosition.z);
    }
}
