using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public enum TypeTag // agar tag bisa dipilih melalui unity
{
    Player,
    VTrap,
    Htrap,
    Checkpoint,
    Finish
}

public class EventTrigger : MonoBehaviour
{
    public TypeTag targetTag;
    private string tagName;
    public UnityEvent OnTrigger;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        tagName = targetTag.ToString();

        if (coll.gameObject.tag == tagName)
        {
            Debug.Log(gameObject.tag + " Kena! " + coll.gameObject.tag);
            OnTrigger?.Invoke();
        }
    }
}
