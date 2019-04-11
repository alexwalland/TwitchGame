using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;

	public bool move = false;

	public Vector2 mForce;
	public Vector2 mForce2;

	public bool moveable = true;

	public float health = 100;
    float lives = 3;

	public float dHealth = 100;
    public float initialSpeed;
	public Transform spawn;
    int score = 0;
    public fistController fist;
    float delay;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
        initialSpeed = speed;
	}
		

	void FixedUpdate()
	{
        delay += Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Z) && delay > 60)
        {
            fist.selectWeapon(1);
            delay = 0;
        }

        if (Input.GetKeyDown(KeyCode.X) && delay > 60)
        {
            fist.selectWeapon(2);
            delay = 0;
        }

        if (Input.GetKeyDown(KeyCode.C) && delay > 60)
        {
            fist.selectWeapon(3);
            delay = 0;
        }

        Vector2 direction = Camera.main.ScreenToWorldPoint (Input.mousePosition)- transform.position;
		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rot = Quaternion.AngleAxis (angle, Vector3.forward);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		rb.angularVelocity = 0;

		float input = Input.GetAxis ("Vertical");
		if (input == 0) {
			move = false;
			mForce = new Vector2(0,0);
		} else 
		{
			move = true;
			mForce = (gameObject.transform.right * speed * input);
		}

		float input2 = Input.GetAxis ("Horizontal");
		if (input2 == 0) {
			move = false;
			mForce2 = new Vector2(0,0);
		} else 
		{
			move = true;
			mForce2 = (gameObject.transform.up * speed * input2 * -1);
		}

		Vector2 test = mForce + mForce2;

		if (!moveable) {
			test = new Vector2 (0, 0);
		}

		rb.AddForce (test);
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "enemy") {
			health -= col.gameObject.GetComponent<PatrolBot> ().damage;
			if (health <= 0 ) {
                lives--;
                if (lives <= 0)
                {
                    SceneManager.LoadScene(0);
                }
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				foreach (Transform fist in transform) {
					fist.gameObject.SetActive (false);
				}
				Invoke ("Respawn", 2f);
			}
			if (health > 0) {
				gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				StartCoroutine (Blink (1));
				Invoke ("RenableCollision", 1);
			}
			}
			if (col.gameObject.tag == "enemy3") {
			health -= col.gameObject.GetComponent<bMove> ().damage;
			if (health <= 0) {
                lives--;
                if (lives <= 0)
                {
                    SceneManager.LoadScene(0);
                }
                gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				foreach (Transform fist in transform) {
					fist.gameObject.SetActive (false);
				}
				Invoke ("Respawn", 2f);
			}
			if (health > 0) {
				gameObject.GetComponent<CircleCollider2D> ().enabled = false;
				StartCoroutine (Blink (1));
				Invoke ("RenableCollision", 1);
			}
		}
	}

	void RenableCollision()
	{
		gameObject.GetComponent<CircleCollider2D> ().enabled = true;
	}

	IEnumerator Blink(float waitTime) {
		float endTime = Time.time + waitTime;
		while (Time.time < endTime) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			foreach (Transform fist in transform) {
				fist.gameObject.SetActive (false);
			}
			yield return new WaitForSeconds(0.2f);
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			foreach (Transform fist in transform) {
				fist.gameObject.SetActive (true);
			}
			yield return new WaitForSeconds (0.2f);
		}
	}

	void Respawn(){
		transform.position = spawn.position;
		health = dHealth;
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		gameObject.GetComponent<CircleCollider2D> ().enabled = true;
		foreach (Transform fist in transform) {
			fist.gameObject.SetActive (true);
		}
	}

	public void addScore(int points) {
		score += points;
	}
}
