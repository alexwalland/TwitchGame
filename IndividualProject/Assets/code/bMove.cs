using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bMove : MonoBehaviour {

	public int speed = 1000;
	public float lifeTime = 2;
	public float damage = 10;

	void Start()
    {
        Destroy (gameObject, lifeTime);
	}

	void Update ()
    {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy (gameObject);
	}
}