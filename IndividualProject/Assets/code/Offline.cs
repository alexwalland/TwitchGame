using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offline : MonoBehaviour
{
    public GameObject player;
    public Weapon[] guns;
    public fistController fist;
    public knife knife;
    public bMove[] bullets;
    public AudioSource[] songs;

    int difficulty = 1;

    float gTimer = 0;
    float pETimer = 0;
    public float sTimer = 0;
    float gETimer = 0;


    // Update is called once per frame
    void Update()
    {
        gTimer += Time.deltaTime;
        pETimer += Time.deltaTime;
        sTimer += Time.deltaTime;
        gETimer += Time.deltaTime;
        PlayerPrefs.SetInt("difficulty", difficulty);
        RandomChoice();
    }

    void RandomChoice()
    {
        if (gTimer > 30)
        {
            gTimer = 0;
            int i = Random.Range(0, 9);
            fist.selectWeapon(i);
        }
        if (pETimer >15)
        {
            pETimer = 0;
            int s = Random.Range(0,5);
            if (s == 0)
            {
                player.GetComponent<PlayerController>().health = player.GetComponent<PlayerController>().dHealth;
            }
            if (s == 1)
            {
                for (int i = 0; i < bullets.Length; i++)
                {
                    if (bullets[i].damage > 10)
                    {
                        bullets[i].damage = 10;
                    }
                }
            }
            if (s == 2)
            {
                for (int i = 0; i < bullets.Length; i++)
                {
                    if (bullets[i].damage < 20)
                    {
                        bullets[i].damage = 20;
                    }
                }
                knife.damage = 15;
                fist.damage = 12;
            }
            if (s == 3)
            {
                fist.speed = 3;
            }
            if (s == 4)
            {
                player.GetComponent<PlayerController>().speed = player.GetComponent<PlayerController>().initialSpeed * 1.5f;
            }
            if (s == 5)
            {
                player.GetComponent<PlayerController>().speed = player.GetComponent<PlayerController>().initialSpeed * 0.5f;
            }
            if (s == 6)
            {
                guns[2].fireRate = 3;
            }
            if (s == 7)
            {
                player.GetComponent<PlayerController>().health *= 1.5f;
                player.GetComponent<PlayerController>().dHealth *= 1.5f;
            }
            if (s == 8)
            {
                player.GetComponent<PlayerController>().health *= 0.5f;
                player.GetComponent<PlayerController>().dHealth *= 0.5f;
            }
            if (s == 9)
            {
                player.GetComponent<PlayerController>().dHealth = 100f;
                player.GetComponent<PlayerController>().speed = player.GetComponent<PlayerController>().initialSpeed;
                knife.damage = 8;
                fist.damage = 6;
                guns[2].fireRate = guns[2].initialFireRate;
            }
        }
        if (gETimer > 20)
        {
            gETimer = 0;
            int g = Random.Range(0, 4);
            if (g == 0)
            {
                difficulty++;
            }
            if (g == 1)
            {
                difficulty--;
            }
            if (g == 2)
            {
                Time.timeScale = 0.5f;
            }
            if (g == 3)
            {
                Time.timeScale = 1.5f;
            }
            if (g == 4)
            {
                Time.timeScale = 1;
            }
        }
        if (sTimer > 90)
        {
            sTimer = 0;
            int w = Random.Range(0, 6);
            for (int v = 0; v < songs.Length; v++)
            {
                songs[v].Stop();
            }
            songs[w].Play();
        }
    }
}
