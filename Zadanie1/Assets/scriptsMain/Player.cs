using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Player : MonoBehaviour {


	public Text napis;
	public GameObject EndPanel;
	public timer czas;
	public GameObject[] M1, M2, M3;
	public GameObject[] pionki;
	public Vector2 mouseOver;

	public pinPair[] pairs = new pinPair[10];
	public pinPair pair_temp;
	private GameObject pionek_temp;
	//-----------------------------------------------------------------------------------------
	private void LegalityCheckGlobal (pinPair[] pairs)
	{
		for (int i = 0; i <= 9; i++) 
		{
			if (pairs [i].CheckIfLegalPin (pairs))
				pairs [i].pin.gameObject.tag = "legal";
		}
		GameObject[] pins_temp = GameObject.FindGameObjectsWithTag ("legal");
		Debug.Log (pins_temp.Length);
	}
	//-----------------------------------------------------------------------------------------
	private void SetAllIllegal (pinPair pairs_)
	{
		foreach (pinPair pair in pairs_) 
		{
			pair.pin.tag = "illegal";
		}
	}
	private void UpdateMouse()
	{
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 25.0f)) 
		{
			mouseOver.x = (int)hit.point.x;
			mouseOver.y = (int)hit.point.z;
		} 
		else 
		{
			mouseOver.x = -1;
			mouseOver.y = -1;
		}
		if (hit.collider.tag == "Illegal") 
		{
			pionek_temp = hit.collider.gameObject;
			Debug.Log (pionek_temp.tag);
		}
		if (hit.collider.tag == "legal") 
		{
			pionek_temp = hit.collider.gameObject;
			Debug.Log (pionek_temp.tag);
		}
	}
	private void MouseOnClick()
	{
		//Debug.Log ("in function MouseOnClick");
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast (ray, out hit, 25.0f))
		{
			if(hit.transform.tag == "legal")
			{
				//Debug.Log ("Got a legal target");
				pionek_temp = hit.collider.gameObject;//zapisuję pionek na później
				SetAllIllegal(pairs);//illegaluję wszystkie piony, mam zapisany pionek aktywny
			}
		}
	}

	//-----------------------------------------------------------------------------------------

	void Start () 	{
		czas = new timer (napis, EndPanel);

		//deklaracja par--------------------------------
		for (int i = 0; i <= 9; i++) 
		{
			pairs [i] = new pinPair (M1 [i], pionki [i], (int)M1 [i].transform.position.x, (int)M1 [i].transform.position.z);
		}
		pionek_temp = pairs[0].GetPin();
		pionek_temp.SetActive (false);
		pairs[0].CancelPin();
		pionki [0] = null;
		//koniec deklaracji par--------------------------
		Debug.Log(pairs [5].CheckIfLegalPin (pairs));
		LegalityCheckGlobal (pairs);
	}
	
	// Update is called once per frame
	void Update () 
	{
		czas.CountTime ();
		//UpdateMouse ();
		if (Input.GetMouseButtonDown (0)) {
			//Debug.Log ("mouse clickedf");
			MouseOnClick ();
	
		}
	}

}



/*
 * 	
 * funkcja nie dziala
 * 	//-----------------------------------------------------------------------------------------
private void MovePinTowards(GameObject pin, GameObject home)
{
	bool movement = true;
	bool movement1 = false;
	Vector3 target, buffor;
	float speed = 0.001f;
	buffor = Vector3.zero;
	buffor.y = 5;
	target = pin.transform.position + buffor;
	Debug.Log (target);
	Debug.Log (pin.transform.position);
	Debug.Log (buffor);
	Debug.Log ("inside MovePinTowards");
	while (movement) 
	{
		//pin.transform.position = Vector3.MoveTowards (pin.transform.position, target, speed);
		pin.transform.Translate(Vector3.up * Time.deltaTime);
		if (pin.transform.position == target) 
		{
			movement1 = true;
			movement = false;
		}

	}
	if (movement) 
	{
		pin.transform.position = Vector3.MoveTowards (pin.transform.position, home.transform.position, speed);
	}
}
//-----------------------------------------------------------------------------------------

 * funkcja nie dziala
  void CheckLegality() //sprawdzam legalność, bledna funkcja, do poprawy
	{
		//for (int i = 1; 1<=3; i++)
		//{
			GameObject[] a = M1;				

		if (a[3].CompareTag("occ") && a[4].CompareTag("occ") && a[5].CompareTag("Nocc"))
		{
			foreach (GameObject pionek in pionki)
			{
				if (pionek.transform.position == a [3].transform.position)
					pionek.gameObject.tag = "legal";

			}
		}
		if (a[5].CompareTag("occ") && a[4].CompareTag("occ") && a[3].CompareTag("Nocc"))
		{
			foreach (GameObject pionek in pionki)
			{
				if (pionek.transform.position == a [5].transform.position)
					pionek.gameObject.tag = "legal";

			}
		}
		if (a[6].CompareTag("occ") && a[7].CompareTag("occ") && a[8].CompareTag("Nocc"))
		{
			foreach (GameObject pionek in pionki)
			{
				if (pionek.transform.position == a [6].transform.position)
					pionek.gameObject.tag = "legal";

			}
		}
		if (a[7].CompareTag("occ") && a[8].CompareTag("occ") && a[9].CompareTag("Nocc"))
		{
			foreach (GameObject pionek in pionki)
			{
				if (pionek.transform.position == a [7].transform.position)
					pionek.gameObject.tag = "legal";

			}
		}
		if (a[8].CompareTag("occ") && a[7].CompareTag("occ") && a[6].CompareTag("Nocc"))
		{
			foreach (GameObject pionek in pionki)
			{
				if (pionek.transform.position == a [8].transform.position)
					pionek.gameObject.tag = "legal";

			}
		}
		if (a[9].CompareTag("occ") && a[8].CompareTag("occ") && a[7].CompareTag("Nocc"))
		{
			foreach (GameObject pionek in pionki)
			{
				if (pionek.transform.position == a [9].transform.position)
					pionek.gameObject.tag = "legal";

			}
		}
 */
