using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    [Range(0f, 5f)] public float delay;

    private void Camfollow()
    {
        //cam.transform.position.x = player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Camfollow", delay);
    }
}
