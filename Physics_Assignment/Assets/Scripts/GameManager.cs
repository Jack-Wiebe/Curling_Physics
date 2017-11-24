using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Charge charge;
	public GameObject Stone;
	public float mass;

	void Start () {
		
	}

	public void Change_Mass(float value)
	{
		Stone.GetComponent<Rigidbody> ().mass=value * 10;
	}

	// Update is called once per frame
	void Update () {
		Handle_Input ();
	}

	void Handle_Input()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			charge.Toggle_Visibility ();
			StartCoroutine (charge.charge_co);
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			StopCoroutine (charge.charge_co);
			charge.Toggle_Visibility ();
			Set_Stats ();
		}
	}

	private float Calculate_Force ()
	{
		return Stone.GetComponent<Rigidbody> ().mass*charge.m_ChargeAmount;
	}

	private void Set_Stats ()
	{
		Stone.GetComponent<Rigidbody> ().AddForce (Vector3.forward * Calculate_Force(), ForceMode.Impulse);
	}


}
