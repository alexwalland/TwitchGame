using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherFist : MonoBehaviour {

	public Vector3 fist;

	void Start () {
		fist = gameObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.localPosition = fist;
	}
}
