using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour
{

    public GameObject[] bots;
    public GameObject[] nBots;
    public GameObject[] tBots;
    public GameObject[] sBots;

    public float nTimer = 0;
    public float tTimer = 0;
    public float sTimer = 0;

    public float nDelay = 30;
    public float tDelay = 45;
    public float sDelay = 30;

    public float tWave = 0;
    public float sWave = 0;

    public Transform spawn;
    public Transform spawn2;
    public Vector3 point;

    void Start()
    {
        SpawnPatrol(Random.Range(3, 5));
    }

    void Update()
    {
        nBots = GameObject.FindGameObjectsWithTag("normal");
        if (nBots.Length == 0)
        {
            SpawnPatrol(Random.Range(2, 4));
        }

        tBots = GameObject.FindGameObjectsWithTag("turret");
        if (tBots.Length == 0 && tWave > 0)
        {
            SpawnTurret(Random.Range(1, 3));
        }

        sBots = GameObject.FindGameObjectsWithTag("shield");
        if (sBots.Length == 0 && sWave > 0)
        {
            SpawnShield(Random.Range(2, 4));
        }

        if (PlayerPrefs.GetInt("difficulty") > 1)
        {
            nDelay = 15;
            tDelay = 25;
            sDelay = 15;
        }
        else if (PlayerPrefs.GetInt("difficulty") > 2)
        {
            nDelay = 8;
            tDelay = 15;
            sDelay = 7;
        }
        else
        {
            nDelay = 30;
            tDelay = 45;
            sDelay = 30;
        }

        nTimer += Time.deltaTime;
        tTimer += Time.deltaTime;
        sTimer += Time.deltaTime;

        if (nTimer > nDelay)
        {
            nTimer = 0;
            SpawnPatrol(Random.Range(1, 2));
        }

        if (tTimer > tDelay)
        {
            tTimer = 0;
            SpawnTurret(Random.Range(1,2));
        }

        if (sTimer > sDelay)
        {
            sTimer = 0;
            SpawnShield(Random.Range(1,2));
        }
    }

    void SpawnPatrol(int a)
    {
        for (int i=0; i < a; i++)
        {
            point = new Vector3(Random.Range(spawn.position.x, spawn2.position.x), Random.Range(spawn.position.y, spawn2.position.y), 0);
            Instantiate(bots[0], point, transform.rotation);
        }
    }

    void SpawnTurret(int b)
    {
        for (int i = 0; i < b; i++)
        {
            point = new Vector3(Random.Range(spawn.position.x, spawn2.position.x), Random.Range(spawn.position.y, spawn2.position.y), 0);
            Instantiate(bots[1], point, transform.rotation);
        }
        tWave++;
    }

    void SpawnShield(int c)
    {
        for (int i = 0; i < c; i++)
        {
            point = new Vector3(Random.Range(spawn.position.x, spawn2.position.x), Random.Range(spawn.position.y, spawn2.position.y), 0);
            Instantiate(bots[2], point, transform.rotation);
        }
        sWave++;
    }
}
