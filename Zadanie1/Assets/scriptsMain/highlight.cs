using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class highlight : MonoBehaviour {
	public GameObject copy;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnMouseEnter()
	{
		if (gameObject.CompareTag ("legal")) {
			copy.gameObject.SetActive (true);
		}
	}
	void OnMouseExit()
	{
		if (gameObject.CompareTag ("legal")) {
			copy.gameObject.SetActive (false);
		}
	}


}
