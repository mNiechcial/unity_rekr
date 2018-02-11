using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Player : MonoBehaviour {


	public Text napis;
	public timer czas;
	public GameObject[] M1, M2, M3;
	public GameObject[] pionki;
	public Vector2 mouseOver;

	public pinPair[] pairs = new pinPair[10];
	public pinPair jedna_para;
	private GameObject pionek_temp;

	private void UpdateMouse()
	{
		RaycastHit hit;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f))
		{
			mouseOver.x = (int)hit.point.x;
			mouseOver.y = (int)hit.point.z;
		}
		else
		{
			mouseOver.x = -1;
			mouseOver.y = -1;
		}
		if(hit.collider.tag == "Illegal")
		{
			pionek_temp = hit.collider.gameObject;
			Debug.Log (pionek_temp);
		}

	//Debug.Log(mouseOver);

	}

	// Use this for initialization
	void Start () {
		czas = new timer (napis);

		//deklaracja par--------------------------------
		for (int i = 0; i <= 9; i++) 
		{
			pairs [i] = new pinPair (M1 [i], pionki [i], (int)M1 [i].transform.position.x, (int)M1 [i].transform.position.y);
		}
		pionek_temp = pairs[0].GetPin();
		pionek_temp.SetActive (false);

		//koniec deklaracji par--------------------------
	}
	
	// Update is called once per frame
	void Update () {
		czas.CountTime ();
		UpdateMouse();

	}



}



/*
 * 		

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
