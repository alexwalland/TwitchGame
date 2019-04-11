using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public float initialFireRate;

	float fireTime;
 	Transform barrel;
	public GameObject fist;

	public Transform bulletPrefab;
    public AudioSource shot;

	// Use this for initialization
	void Awake () {
		initialFireRate = fireRate;
		barrel = transform.Find ("barrel");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (fireRate == 0)
        {
			if (Input.GetMouseButtonDown (0))
            {
				Shoot ();
                shot.Play();
			}
		} else
        {
			if (Input.GetMouseButton (0) && Time.time > fireTime)
            {
				fireTime = Time.time + 1 / fireRate;
				Shoot ();
                shot.Play();
			}
	    }
	}

	void Shoot()	{
		Instantiate (bulletPrefab, barrel.position, barrel.rotation);
	}
}
