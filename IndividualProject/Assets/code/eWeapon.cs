using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eWeapon : MonoBehaviour {

	public float firerate;
    public float hardFireRate;
    public float FR;
    public AudioSource gunFire;

	Transform barrel;
	public Transform bulletPrefab;

	void Start () {
        FR = firerate;
		barrel = transform.Find ("barrel");
		Invoke ("Shoot", 5 / FR);
	}
	
	void Update ()
    {
        if (PlayerPrefs.GetInt("difficulty") > 2)
        {
            FR = hardFireRate;
        }
        else
        {
            FR = firerate;
        }
	}

	void Shoot()	{
		Instantiate (bulletPrefab, barrel.position, barrel.rotation);
        gunFire.Play();
		Invoke ("Shoot", 5 / firerate);
	}
}
