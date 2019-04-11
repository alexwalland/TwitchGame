using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBot : MonoBehaviour
{
    Transform player;
    Transform pointA;
    Transform pointB;

    private Rigidbody2D rb;
    public float health = 100;
    public int points = 100;

    public float rTimer = 0;
    public float tTimer = 0;

    void Start()
    {
        Rotate();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pointA = GameObject.FindGameObjectWithTag("a").transform;
        pointB = GameObject.FindGameObjectWithTag("b").transform;
    }
    
    void FixedUpdate()
    {
        rTimer += Time.deltaTime;
        tTimer += Time.deltaTime;

        if (rTimer > 15 && PlayerPrefs.GetInt("difficulty") < 2)
        {
            Rotate();
            rTimer = 0;
        }

        if (PlayerPrefs.GetInt("difficulty") > 1)
        {
            if (tTimer > 30)
            {
                tTimer = 0;
                Teleport();
            }
            float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(0, 0, z);
        }
    }

    void Rotate()
    {
        int angle = Random.Range(45, 270);
        transform.Rotate(0, 0, angle);
    }

    void Teleport()
    {
        Vector3 c = new Vector3(Random.Range(pointA.position.x, pointB.position.x), Random.Range(pointA.position.y, pointB.position.y), 0);
        transform.position = c;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            health -= col.gameObject.GetComponent<bMove>().damage;
            if (health <= 0)
            {
                Destroy(gameObject);
                player.GetComponent<PlayerController>().addScore(points);
            }
        }
        if (col.gameObject.tag == "fist")
        {
            health -= col.gameObject.GetComponent<fistController>().damage;
            if (health <= 0)
            {
                Destroy(gameObject);
                player.GetComponent<PlayerController>().addScore(points);
            }
        }
        if (col.gameObject.tag == "knife")
        {
            health -= col.gameObject.GetComponent<knife>().damage;
            if (health <= 0)
            {
                Destroy(gameObject);
                player.GetComponent<PlayerController>().addScore(points);
            }
        }
    }
}
