using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	public Vector3 initPos;
	public Vector3 finalPos;

	private Rigidbody m_rbRef; 

	public GameObject Marker;

	public bool isCurling;
	// Use this for initialization
	void Start () {
		m_rbRef = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		if (isCurling)
		{
			if (m_rbRef.velocity.magnitude < .1) {
				GameManager.NextStone ();
				isCurling = false;
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		initPos = this.transform.position;
	}

	void OnCollisionExit(Collision col)
	{
		finalPos = this.transform.position;
		float displacement = (finalPos - initPos).magnitude;
		float forceAccel = m_rbRef.velocity.magnitude * m_rbRef.velocity.magnitude / (2 * displacement);

		float dynamicFrictionForce = Physics.gravity.magnitude * m_rbRef.mass * this.GetComponent<BoxCollider> ().material.dynamicFriction * 2;
		float frictionAccel = dynamicFrictionForce / m_rbRef.mass;
		float finalDisplacement = -m_rbRef.velocity.magnitude * m_rbRef.velocity.magnitude / (2 * dynamicFrictionForce);
		Vector3 pos = (this.transform.position + this.transform.forward * -finalDisplacement);
		//Instantiate (Marker, pos, this.transform.rotation);

		isCurling = true;
	}
}
