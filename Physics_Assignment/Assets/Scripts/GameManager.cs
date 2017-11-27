using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static Charge charge;
	public static GameObject Stone;
	public static GameObject Player;
	public static Vector3 startPlayerLoc;
	public static Vector3 startStoneLoc;
	public static float acceleration = 10.0f;
	public float m_netForce = 0.0f;

	public static int currentRound = 0;

	public static bool isCurling = false;

	public static GameObject marker;

	void Start () {
		isCurling = false;
		Player = GameObject.FindGameObjectWithTag ("Player");
		Stone = GameObject.FindGameObjectWithTag ("Stone");
		startStoneLoc = Stone.transform.position;
		startPlayerLoc = Player.transform.position;
		Player.GetComponent<Rigidbody> ().isKinematic = false;
	}

	public static void NextStone()
	{
		if (currentRound < 3) {
			Player.GetComponent<Rigidbody> ().isKinematic = false;
			Player.transform.position = startPlayerLoc;
			Stone.transform.position = startStoneLoc;
			currentRound++;
		}
	}

	public void Change_Mass(float value)
	{
		Stone.GetComponent<Rigidbody> ().mass=value * 10;
	}

	public void Change_Accel(float value)
	{
		Stone.GetComponent<Rigidbody> ().mass=value;
	}

	// Update is called once per frame
	void Update () {
		Handle_Input ();
	}

	void FixedUpdate()
	{
		if (isCurling) {
			//Vector3 force = this.transform.forward * acceleration;
			Player.GetComponent<Rigidbody>().AddForce(Player.transform.forward * acceleration);
		}
	}

	void Handle_Input()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			isCurling = true;
			//charge.Toggle_Visibility ();
			//charge.m_ChargeAmount = 0;
			//StartCoroutine (charge.charge_co);
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			isCurling = false;
			//StopCoroutine (charge.charge_co);
			//charge.Toggle_Visibility ();
			//Set_Stats ();
			//Calculate_ForceFriction ();
		}
	}

	private float Calculate_ForceAccel ()
	{
		return Stone.GetComponent<Rigidbody> ().mass*charge.m_ChargeAmount;
	}

	private void Calculate_ForceFriction ()
	{

		float normalForce = Mathf.Abs (Stone.GetComponent<Rigidbody> ().mass * Physics.gravity.y);
		float dynamicFriction = normalForce * Stone.GetComponent<BoxCollider> ().material.dynamicFriction * 2;
	
		float frictionAccel =  dynamicFriction / Stone.GetComponent<Rigidbody> ().mass;

	}

	private void Set_Stats ()
	{
		Stone.GetComponent<Rigidbody> ().AddForce (Vector3.forward * Calculate_ForceAccel(), ForceMode.VelocityChange);
		Debug.Log (Stone.GetComponent<Rigidbody> ().velocity.magnitude);
		Debug.Log (Stone.GetComponent<Rigidbody> ().mass * Physics.gravity.magnitude * Stone.GetComponent<BoxCollider> ().material.dynamicFriction * 2);
	}


}
