using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fistController : MonoBehaviour {

	public float speed;

	public Vector2 fForce;

	public Vector3 fist;

	private Rigidbody2D rb;

	public bool active = false;

	private float timer = 0.5f;

	private float timer2 = 0.5f;

	public bool fistW = true;

	PlayerController player;

	public GameObject activeP;
	public int damage = 4;
    public AudioSource punch;
    public AudioSource stab;
    public GameObject knife;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		fist = gameObject.transform.localPosition;
		player = activeP.GetComponent<PlayerController> ();
		selectWeapon(4);
	}

	void Update () {

		if (!active || !fistW) {
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			gameObject.transform.localPosition = fist;
		}
			
			if (active) {
				gameObject.GetComponent<CircleCollider2D> ().enabled = true;
				timer -= Time.deltaTime;
			}
			if (timer < 0) {
				fForce = new Vector2 (0, 0);
				rb.AddForce (fForce);
				gameObject.transform.localPosition = fist;
				active = false;
				timer = timer2;
				player.moveable = true;
			}

		if (Input.GetMouseButtonDown (0) && fistW) {
				player.moveable = false;
				fForce = (gameObject.transform.right * speed);
				active = true;
            if (knife.activeSelf == true)
            {
                stab.Play();
            }
            else
            {
                punch.Play();
            }
         }

		rb.AddForce (fForce);

	}

	public void selectWeapon(int slot)
	{
		int i = 0;
        //change weapon depending on list and set the others to inactive
		if (slot == 4) {
			fistW = true;
			foreach (Transform weapon in transform) {
				weapon.gameObject.SetActive (false);
			}
		} else {
			if (slot > 0) {
				fistW = false;
			} else {
				fistW = true;
			}
			foreach (Transform weapon in transform) {
				if (i == slot)
					weapon.gameObject.SetActive (true);
				else
					weapon.gameObject.SetActive (false);
				    i++;
			 	}
			}
	}

	public void Reset() {
		selectWeapon (4);
	}
}
