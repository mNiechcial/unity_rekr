﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinPair 
{
	public GameObject hole; 
	public GameObject pin;
	public int x;
	public int y;
	public pinPair (GameObject _hole, int _x, int _y)//konstruktor pustego otworu
	{
		hole = _hole;
		x = _x;
		y = _y;
		pin = null;
	}

	public pinPair (GameObject _hole, GameObject _pin, int _x, int _y) //konstruktor otworów z pinami
	{
		hole = _hole;
		x = _x;
		y = _y;
		pin = _pin;
	}
	public GameObject GetPin ()
	{
		return this.pin;
	}
	public void AssignPin (GameObject targetPin)
	{
		this.pin = targetPin;
	}
	public void CancelPin ()
	{
		this.pin.SetActive (false);
		this.pin = null;
	}

	public void MakeMove (pinPair targetPair, pinPair InBetween)
	{
		if (targetPair.pin == null) 
		{
			targetPair.pin = this.pin;
			this.pin = null;
		}
	}


	bool CheckIfLegalPin( pinPair[] pary)
	{
		bool legality = false;
		int xCoor = this.x;//czy to może być jako xCoor?
		int yCoor = this.y;
		int[,] buffor = new int[,] { { 1, 1 }, { -1, -1 }, { 2, 0 }, { -2, 0 } };


		for (int i=0; i<=3; i++)//robię jeden wektor, sprawdzam czy jakaś para się zgadza, robię kolejny wektor, cztery razy
		{
			foreach (pinPair pair in pary)//10 razy
			{
				if (pair.x == (xCoor + buffor[i,0]) && pair.y == yCoor + buffor[i,1] && pair.pin != null)//sprawdzam pozycję otworu i czy jest zajęty, jak tak to idę dalej
				{
					foreach (pinPair pair_ in pary)//10 razy
					{
						if (pair_.x == xCoor + 2*buffor[i,0] && pair_.y == yCoor + 2*buffor[i,1] && pair_.pin == null)//sprawdzam pozycję otworu i czy jest zajęty, jak nie to legalność
							legality = true;
					}
				}

			}
		}
		return legality;
	}
}
//int xCoor, int yCoor,