using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBot : MonoBehaviour
{
     public float initialSpeed;
    public float speed;
    Transform player;
    private Rigidbody2D rb;
    public float health = 100;
    public int points = 150;

    void Start()
    {
       rb = GetComponent<Rigidbody2D> ();
	   player = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 50)
        {
            speed = initialSpeed / 4;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) < 10)
        {
            speed = 0;
        }
        else
        {
            speed = initialSpeed;
        }
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 180;
        transform.eulerAngles = new Vector3(0, 0, z);
        rb.AddForce (gameObject.transform.right * speed * -1);
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
