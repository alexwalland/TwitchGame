using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aMove : MonoBehaviour
{
    public int speed = 75;
    public float lifeTime = 3;
    public float damage = 5;
    public AudioSource release;
    public AudioSource hit;

    void Start()
    {
        release.volume = PlayerPrefs.GetFloat("VFXVolume");
        hit.volume = PlayerPrefs.GetFloat("VFXVolume");
        release.Play(0);
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed * -1);
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        hit.Play(0);
        Destroy(gameObject);
    }
}
