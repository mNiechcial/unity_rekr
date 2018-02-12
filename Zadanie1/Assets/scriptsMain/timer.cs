using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer {

	public float endTime;
	public Text timerText;
	public GameObject EndPanel;		

	public timer (Text timerText_, GameObject EndPanel_)
	{
		endTime = 60f;
		timerText = timerText_;
		EndPanel = EndPanel_;
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
			EndPanel.gameObject.SetActive (true);
		}
	}
}