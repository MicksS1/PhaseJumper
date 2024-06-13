using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Material mat;
    public float dist;

    [Range(0f, 5f)] public float speed = 5f;

    void Start()
    {

    }

    void Update()
    {
        //dist = dist + Time.deltaTime * speed;
        //mat.SetTextureOffset("_MainTex", Vector2.right * dist);
    }
}
