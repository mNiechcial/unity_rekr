using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Player : MonoBehaviour {

	public bool GameOn;
	public Text napis;
	public Text reason;
	public GameObject EndPanel;
	public timer czas;
	public GameObject[] M1, M2, M3;
	public GameObject[] pionki;
	public Vector2 mouseOver;
	public bool pinSaved, holeSaved;
	public bool startOperation;
	public pinPair[] pairs = new pinPair[10];
	public pinPair pair_temp1, pair_temp2;
	private GameObject pionek_temp, otwor_temp;
	//-----------------------------------------------------------------------------------------
	private void LegalityCheckGlobalPins ()
	{
		for (int i = 0; i <= 9; i++) 
		{
			if (pairs [i].CheckIfLegalPin (pairs))
				pairs [i].pin.gameObject.tag = "legal";
		}
		GameObject[] pins_temp = GameObject.FindGameObjectsWithTag ("legal");
		Debug.Log (pins_temp.Length);
		if (pins_temp.Length <= 0)
		{
			GameOn = false;
			EndPanel.SetActive (true);
		}
	}
	//-----------------------------------------------------------------------------------------
	private void LegalityCheckGlobalHoles (pinPair targetedPair)
	{
		foreach (pinPair para in pairs) 
		{
			if (para.CheckIfLegalHole (pairs, targetedPair))
				para.hole.gameObject.tag = "legal";
		}
	}
	//-----------------------------------------------------------------------------------------
	private void SetAllPinsIllegal (pinPair[] pairs_)
	{
		foreach (pinPair pair in pairs_) 
		{
			if (pair.pin != null)
			pair.pin.tag = "Illegal";
		}
	}
	//-----------------------------------------------------------------------------------------
	private void UpdateMouse()
	{
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 25.0f)) 
		{

			mouseOver.x = (int)hit.point.x;
			mouseOver.y = (int)hit.point.z;

			if (pinSaved && hit.collider.tag == "legal")
			{
				otwor_temp = hit.collider.gameObject;
				otwor_temp.tag = "Illegal";
				foreach (pinPair temp in pairs) 
				{
					if (temp.hole == hit.collider.gameObject && temp.pin == null) {
						holeSaved = true;
						pair_temp2 = temp;//przypisuje parę z otworu
						Debug.Log ("dupa klick 2");
						startOperation = true;

					}
				}

			}	

			if (!pinSaved && hit.collider.tag == "legal") 
			{	
				SetAllPinsIllegal(pairs);
				pionek_temp = hit.collider.gameObject;
				pionek_temp.tag = "Illegal";
				foreach (pinPair temp in pairs)
					if (temp.x == mouseOver.x && temp.y == mouseOver.y) 
					{
						pinSaved = true;
						pair_temp1 = temp;//przypisuje parę z pinu 
						Debug.Log("dupa klick 1");
					}
				LegalityCheckGlobalHoles (pair_temp1);
			}
		} 
	}
	/*	else 
		{
			mouseOver.x = -1;
			mouseOver.y = -1;
		}
		*/
		/*if (hit.collider.tag == "Illegal") 
		{
			pionek_temp = hit.collider.gameObject;
			Debug.Log (pionek_temp.tag);
		}
		if (hit.collider.tag == "legal") 
		{
			pionek_temp = hit.collider.gameObject;
			Debug.Log (pionek_temp.tag);
		}

		*/	
	
	//-----------------------------------------------------------------------------------------
	private void SetAllHolesIllegal (pinPair[] pairs_)
	{
		foreach (pinPair pair in pairs_) 
		{
			pair.hole.tag = "Illegal";
		}
	}
	//-----------------------------------------------------------------------------------------
	public void MovementOperation (pinPair In, pinPair Out)
	{
		int x_new = Out.x - In.x;
		int y_new = Out.y - In.y;

		x_new = In.x + x_new / 2;
		y_new = In.y + y_new / 2;

		foreach (pinPair search in pairs) 
		{
			if (search.x == x_new && search.y == y_new) 
			{
				Debug.Log ("movement operation finished");
				search.pin.SetActive (false);
				search.CancelPin ();
				Out.AssignPin (In.pin);
				In.CancelPin ();
			}

		}

	}
	//-----------------------------------------------------------------------------------------

	void Start () 	{
		//SET UP, deklaracja par--------------------------------------------------
		czas = new timer (napis, EndPanel, reason);

		for (int i = 0; i <= 9; i++) 
		{
			pairs [i] = new pinPair (M1 [i], pionki [i], (int)M1 [i].transform.position.x, (int)M1 [i].transform.position.z);
		}
		pionek_temp = pairs[0].GetPin();
		pionek_temp.SetActive (false);
		pairs[0].CancelPin();
		pionki [0] = null;
		//koniec deklaracji par------------------------------------------

		LegalityCheckGlobalPins ();
	}

	void Update () 
	{
		if (GameOn)
		czas.CountTime ();//jeśli gra trwa, mierz czas

		if (Input.GetMouseButtonDown (0)) {//czekaj na kliknięcie, jesli jest, to funkcja
			UpdateMouse ();
			//SetAllPinsIllegal(pairs);//illegaluję wszystkie piony, mam zapisany pionek aktywny
		}
		if (startOperation)
			pair_temp1.pin.transform.position = Vector3.MoveTowards (pair_temp1.pin.transform.position, pair_temp2.hole.transform.position, 10f * Time.deltaTime);
		
		if (pair_temp1.pin.transform.position == pair_temp2.hole.transform.position) 
		{
			startOperation = false;
			MovementOperation (pair_temp1, pair_temp2);
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


	private void MouseOnClick(pinPair[] szukaj)
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
				foreach (pinPair pair in szukaj)
				{
					if (pair.pin == pionek_temp)
					{
						pair_temp1 = pair;
						Debug.Log (pair_temp1);
					}

				}

			}
		}
	}
 */
