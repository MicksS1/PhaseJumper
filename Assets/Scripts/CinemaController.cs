using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemaController : MonoBehaviour
{
    public CinemachineBrain brain;

    void Start()
    {
        brain = GetComponent<CinemachineBrain>();
        brain.m_UpdateMethod = CinemachineBrain.UpdateMethod.FixedUpdate;
    }
}
