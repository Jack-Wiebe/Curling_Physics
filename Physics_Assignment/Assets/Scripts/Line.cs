using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c)
	{
		Debug.Log ("sdjfhjs");
		if (c.CompareTag ("Player")) {
			c.GetComponent<Rigidbody> ().isKinematic = true;
		}
	}
}
