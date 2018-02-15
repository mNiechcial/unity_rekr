using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinPair 
{
	public GameObject hole; 
	public GameObject pin;
	public int x;
	public int y;

	//-----------------------------------------------------------------------------------------
	public pinPair (GameObject _hole, int _x, int _y)//konstruktor pustego otworu
	{
		hole = _hole;
		x = _x;
		y = _y;
		pin = null;
	}
	//-----------------------------------------------------------------------------------------
	public pinPair (GameObject _hole, GameObject _pin, int _x, int _y) //konstruktor otworów z pinami
	{
		hole = _hole;
		x = _x;
		y = _y;
		pin = _pin;
	}
	//-----------------------------------------------------------------------------------------
	public GameObject GetPin ()
	{
		return this.pin;
	}
	//-----------------------------------------------------------------------------------------
	public void AssignPin (GameObject targetPin)
	{
		this.pin = targetPin;
	}
	//-----------------------------------------------------------------------------------------
	public void CancelPin ()
	{
		//this.pin.SetActive (false);
		this.pin = null;
	}
	//-----------------------------------------------------------------------------------------
	public void MakeMove (pinPair targetPair, pinPair InBetween)
	{
		if (targetPair.pin == null) 
		{
			targetPair.pin = this.pin;
			this.pin = null;
		}
	}
	//-----------------------------------------------------------------------------------------
	public bool CheckIfLegalPin( pinPair[] pary)
	{
		bool legality = false;
		int xCoor = this.x;
		int yCoor = this.y;
		int[,] buffor = new int[,] { { 1, 1 }, { -1, -1 }, { 1, -1 }, { -1, 1 }, { 0, 2 }, { 0, -2 } };
		//Debug.Log (xCoor);
		//Debug.Log (yCoor);
		//Debug.Log ("Begin Checking legality");
		//Debug.Log ("Checking vector");
		//Debug.Log (xCoor + buffor [i, 0]);
		//Debug.Log (yCoor + buffor [i, 1]);
		for (int i = 0; i <= 5; i++)//mam 6 wektorów
		{
			foreach (pinPair pair in pary) 
			{//10 razy

				if (pair.x == (xCoor + buffor [i, 0]) && pair.y == yCoor + buffor [i, 1] && pair.pin != null) //sprawdzam pozycję otworu i czy jest zajęty, jak tak to idę dalej
				{

					foreach (pinPair pair_ in pary) 
					{//10 razy
						//Debug.Log ("foreach to second if");
						if (pair_.x == xCoor + 2 * buffor [i, 0] && pair_.y == yCoor + 2 * buffor [i, 1] && pair_.pin == null)//sprawdzam pozycję otworu i czy jest zajęty, jak nie to legalność
						{
							legality = true;//tutaj zagwozdka - muszę najpierw ustawiać flagę legalności, bo chcę używać tą funkcję do sprawdzania końca gry, w konsekwencji tego zmieniam tag na legality w skrypcie gracza
						}
					}
				}
			}
		}
	return legality;
	}

//-----------------------------------------------------------------------------------------
	public bool CheckIfLegalHole(pinPair[] pary, pinPair TargetedPair)
	{
		bool legality = false;
		int xCoor = TargetedPair.x;
		int yCoor = TargetedPair.y;
		int[,] buffor = new int[,] { { 1, 1 }, { -1, -1 }, { 1, -1 }, { -1, 1 }, { 0, 2 }, { 0, -2 } };
		Debug.Log (this.pin);
		if (this.pin == null) //czy otwór dla którego wywołuję jest pusty?
		{
			for (int i = 0; i <= 5; i++) //robię jeden wektor, sprawdzam czy jakaś para się zgadza, robię kolejny wektor, cztery razy
			{ 
				foreach (pinPair pair in pary) {//10 razy

					if (pair.x == (xCoor + buffor [i, 0]) && pair.y == yCoor + buffor [i, 1] && pair.pin != null) //sprawdzam pozycję dowolnego otworu i czy jest zajęty, jak tak to idę dalej
					{
						
						foreach (pinPair pair_ in pary) 
						{
							if (pair_.x == xCoor + 2 * buffor [i, 0] && pair_.y == yCoor + 2 * buffor [i, 1] && pair_ == this) //sprawdzam czy po przekątnej jest wybrany otwór
							{
								legality = true;
							}
						}
					}
				}
			}	
		}
		return legality;
	}



}