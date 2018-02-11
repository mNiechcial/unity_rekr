using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Player : MonoBehaviour {


	public class ruch {
		int M; //macierz wzgledem ktorej jest wykonywany ruch
		int pozycja_wej;
		int pozycja_wyj;
		float czas_ruchu;

	}

	public class timer {

		public float endTime;
		public Text timerText;

		public timer (Text timerText_)
		{
			endTime = 10f;
			timerText = timerText_;
		}


		float GetTime()
		{
			return (endTime);
		}


		public void CountTime () {

			if (endTime > 0.0f) 
			{
				endTime -= Time.deltaTime;
				timerText.text = endTime.ToString("0.0");
			}

			if (endTime <= 0.0f) 
			{
				timerText.text = ("KONIEC CZASU");	
			}
		}
	}
	public Text napis;
	public timer czas;
	public GameObject[] M1, M2, M3;
	public GameObject[] pionki;
	public bool legalityCheck = false;


	void CheckLegality()
	{


													//sprawdzam legalność

		if (M1[3].CompareTag("occ") && M1[4].CompareTag("occ") && M1[5].CompareTag("Nocc"))
		{
			foreach (GameObject pionek in pionki)
			{
				if (pionek.transform.position == M1 [3].transform.position)
					pionek.gameObject.tag = "legal";
			}
		}
		if (M1[5].CompareTag("occ") && M1[4].CompareTag("occ") && M1[3].CompareTag("Nocc"))
		{
			foreach (GameObject pionek in pionki)
			{
				if (pionek.transform.position == M1 [5].transform.position)
					pionek.gameObject.tag = "legal";
			}
		}
		if (M1[6].CompareTag("occ") && M1[7].CompareTag("occ") && M1[8].CompareTag("Nocc"))
		{
			foreach (GameObject pionek in pionki)
			{
				if (pionek.transform.position == M1 [6].transform.position)
					pionek.gameObject.tag = "legal";
			}
		}
		if (M1[7].CompareTag("occ") && M1[8].CompareTag("occ") && M1[9].CompareTag("Nocc"))
		{
			foreach (GameObject pionek in pionki)
			{
				if (pionek.transform.position == M1 [7].transform.position)
					pionek.gameObject.tag = "legal";
			}
		}
		if (M1[8].CompareTag("occ") && M1[7].CompareTag("occ") && M1[6].CompareTag("Nocc"))
		{
			foreach (GameObject pionek in pionki)
			{
				if (pionek.transform.position == M1 [8].transform.position)
					pionek.gameObject.tag = "legal";
			}
		}
		if (M1[9].CompareTag("occ") && M1[8].CompareTag("occ") && M1[7].CompareTag("Nocc"))
		{
			foreach (GameObject pionek in pionki)
			{
				if (pionek.transform.position == M1 [9].transform.position)
					pionek.gameObject.tag = "legal";
			}
		}

		legalityCheck = true; 		//kończę sprawdzanie
	}

	// Use this for initialization
	void Start () {
		czas = new timer (napis);
	}
	
	// Update is called once per frame
	void Update () {
		czas.CountTime ();

		if (!legalityCheck)
			CheckLegality ();

	}



}


