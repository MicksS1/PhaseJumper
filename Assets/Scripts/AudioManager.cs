using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] ost, sfx;
    public AudioSource ostSource;
    public AudioSource sfxSource;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        
        } else
            Destroy(gameObject);
    }

    private void Start()
    {
        playOst("OST");
    }

    public void playOst(string name)
    {
        Sound a = Array.Find(ost, x => x.name == name);

        if (a != null)
        {
            ostSource.clip = a.clip;
            ostSource.Play();
            ostSource.loop = true;
        }
    }

    public void playSfx(string name)
    {
        Sound a = Array.Find(sfx, x => x.name == name);

        if (a != null)
        {
            sfxSource.PlayOneShot(a.clip);
        }
    }

    public void finishSlowMo()
    {
        ostSource.pitch = 0.8f;
        Invoke("SlowMoReset", 0.3f);
    }

    public void SlowMoReset()
    {
        ostSource.pitch = 1f;
    }
}
