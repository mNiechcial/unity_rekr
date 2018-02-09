using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	public float endTime = 10.0f;
	public Text timerText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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
