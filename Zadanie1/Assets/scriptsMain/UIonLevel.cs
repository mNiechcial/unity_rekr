using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class UIonLevel : MonoBehaviour {



	public GameObject EndPanel;		
	public int sceneToStart = 0;	


	public void onClick()
	{
		SceneManager.LoadScene (sceneToStart);
	}

	public void ShowEnd()
	{
		EndPanel.gameObject.SetActive (true);
	}
}