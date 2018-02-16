using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Player : MonoBehaviour {

	public bool GameOn;
	public Text timedisplay;
	public Text reason;
	public GameObject EndPanel;
	public GameObject station;
	public timer czas;
	public GameObject[] M1;
	public GameObject[] pionki;
	public Vector2 mouseOver;
	public bool pinSaved, holeSaved;
	public bool startOperation;
	public pinPair[] pairs;
	public pinPair pair_temp1, pair_temp2;
	private GameObject pionek_temp, otwor_temp;
	//-----------------------------------------------------------------------------------------
	private void LegalityCheckGlobalPins ()
	{
		foreach (pinPair pair in pairs) 
		{
			if (pair.CheckIfLegalPin (pairs) && pair.pin != null)
				pair.pin.gameObject.tag = "legal";
		}
		GameObject[] pins_temp = GameObject.FindGameObjectsWithTag ("legal");
		Debug.Log (pins_temp.Length);
		if (pins_temp.Length <= 0)
		{
			GameOn = false;
			EndPanel.SetActive (true);
			reason.text = "No more legal moves";
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

			if (pinSaved && hit.collider.tag == "legal" && pair_temp1.pin.transform.position == station.transform.position)
			{
				otwor_temp = hit.collider.gameObject;
				otwor_temp.tag = "Illegal";
				foreach (pinPair temp in pairs) 
				{
					if (temp.hole == hit.collider.gameObject && temp.pin == null) {
						holeSaved = true;
						pair_temp2 = temp;//przypisuje parę z otworu
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
					}
				LegalityCheckGlobalHoles (pair_temp1);
			}
		} 
	}
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
				pinSaved = false;
				holeSaved = false;
				pair_temp1 = null;
				pair_temp2 = null;
			}

		}

	}
	//-----------------------------------------------------------------------------------------

	void Start () 	{
		//SET UP, deklaracja par--------------------------------------------------
		pairs = new pinPair[M1.Length];
		czas = new timer (timedisplay, EndPanel, reason);
		Debug.Log ("M1 length" + M1.Length);
		for (int i = 0; i <= M1.Length-1; i++) 
		{
			pairs [i] = new pinPair (M1 [i], pionki [i], (int)M1 [i].transform.position.x, (int)M1 [i].transform.position.z);
		}
		pairs[0].pin.SetActive (false);
		pairs[0].CancelPin();
		pionki [0] = null;
		GameOn = true;
		//koniec deklaracji par------------------------------------------

		LegalityCheckGlobalPins ();
	}

	void Update () 
	{
		if (GameOn)
		czas.CountTime ();//jeśli gra trwa, mierz czas

		if (Input.GetMouseButtonDown (0)) {//czekaj na kliknięcie, jesli jest, to funkcja
			UpdateMouse ();
		}
		if (startOperation)
			pair_temp1.pin.transform.position = Vector3.MoveTowards (pair_temp1.pin.transform.position, pair_temp2.hole.transform.position, 10f * Time.deltaTime);
		
		if (pair_temp1.pin.transform.position == pair_temp2.hole.transform.position) 
		{
			SetAllHolesIllegal (pairs);
			startOperation = false;
			MovementOperation (pair_temp1, pair_temp2);
			LegalityCheckGlobalPins ();
		}
	}
}
