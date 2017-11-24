using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charge : MonoBehaviour {

	public GameObject frame;
	public float m_ChargeAmount;
	public IEnumerator charge_co;
	// Use this for initialization
	void Start () {
		Toggle_Visibility ();
		m_ChargeAmount = 0;
		charge_co = Charge_Up();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale = new Vector3 (m_ChargeAmount/50,this.transform.localScale.y, this.transform.localScale.z);
	}

	public void Toggle_Visibility()
	{
		transform.parent.gameObject.GetComponent<Image> ().enabled = !transform.parent.gameObject.GetComponent<Image> ().enabled;
		this.GetComponent<Image> ().enabled = !this.GetComponent<Image> ().enabled;
	}

	IEnumerator Charge_Up()
	{
		while(m_ChargeAmount < 50)
		{
			m_ChargeAmount += 1;
			yield return new WaitForSeconds (.1f);
		}
	}
}
