using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParController : MonoBehaviour
{
    Transform cam;
    Vector3 camStartPos;
    private float dist;

    GameObject[] background;
    Material[] mat;
    float[] backSpeed;

    float farthestBack;

    [Range(0f, 0.5f)] public float ParSpeed;

    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.transform.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        background = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            background[i] = transform.GetChild(i).gameObject;
            mat[i] = background[i].GetComponent<Renderer>().material;
        }

        BackSpeedCalc(backCount);
    }

    void BackSpeedCalc(int backCount)
    {
        for (int i = 0;i < backCount;i++)
        {
            if ((background[i].transform.position.z - cam.position.z) > farthestBack)
                farthestBack = background[i].transform.position.z - cam.position.z;
        }

        for (int i = 0; i < backCount; i++)
        {
            backSpeed[i] = 1 - (background[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
        dist = cam.position.x - camStartPos.x;

        for (int i = 0; i < background.Length; i++)
        {
            float speed = backSpeed[i] * ParSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(dist, 0) * speed);
        }
    }
}
