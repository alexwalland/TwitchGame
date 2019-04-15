using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatrolBot : MonoBehaviour {

	public float initialSpeed;
    public float speed;
	Transform player;
	private Rigidbody2D rb;
	public float health = 100;
	public int points = 100;

    public float rTimer = 0;
    public float sTimer = 0;
    public float damage = 10;
    public bool reversing = false;

	void Start()
	{
        Rotate();
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void FixedUpdate () {
        rTimer += Time.deltaTime;
        sTimer += Time.deltaTime;
        //checks difficulty and makes the bot behave accordingly 
        if (!reversing)
        {
            if (sTimer > 45)
            {
                sTimer = 0;
            }
            if (rTimer > 20 && PlayerPrefs.GetInt("difficulty") < 2)
            {
                Rotate();
                rTimer = 0;
            }
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
            if (PlayerPrefs.GetInt("difficulty") > 1 || sTimer > 25)
            {
                float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
                transform.eulerAngles = new Vector3(0, 0, z);
            }
        }
        rb.AddForce(speed * transform.up);
        
	}

    void Rotate()
    {
        int angle = Random.Range(45, 315);
        transform.Rotate(0, 0, angle);
    }

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "bullet")
		{
			health -= col.gameObject.GetComponent<bMove> ().damage;
			if (health <= 0) {
				Destroy (gameObject);
				player.GetComponent<PlayerController> ().addScore (points);
			}
		}
		if (col.gameObject.tag == "fist") {
			health -= col.gameObject.GetComponent<fistController> ().damage;
			if (health <= 0) {
				Destroy (gameObject);
				player.GetComponent<PlayerController> ().addScore (points);
			}
		}
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "wall")
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
			reverse();
            Invoke("Reset", 2);
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


    private void Reset()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    void reverse(){
        reversing = true;
		speed *= -1;
		Invoke ("normal", 5);
	}

	void normal(){
        Rotate();
		speed *= -1;
        reversing = false;
	}

}

