using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeController : MonoBehaviour
{
    public AudioSource[] song;
    public AudioSource[] sfx;

    private void Start()
    {
        PlayerPrefs.SetFloat("mV", 1.0f);
    }

    void Update()
    {
        for (int i = 0; i < song.Length; i++)
        {
           song[i].volume = PlayerPrefs.GetFloat("mV");
        }
        for (int i = 0; i < sfx.Length; i++)
        {
            sfx[i].volume = PlayerPrefs.GetFloat("sfxV");
        }

    }
}
