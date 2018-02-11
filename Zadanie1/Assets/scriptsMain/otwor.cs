using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otwor : MonoBehaviour {


	void OnTriggerEnter(Collider other)
	{
		this.gameObject.tag = "occ";
	}
	void OnTriggerExit(Collider other)
	{
		this.gameObject.tag = "Nocc";
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
