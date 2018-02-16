using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickOnClick : MonoBehaviour {

	public bool movement, movement1;
	public Vector3 target, buffor;
	public float speed = 0.1f;
	public GameObject station;
	// Use this for initialization
	void Start () {
		buffor.y = 3;
		target = transform.position + buffor;

	}
	
	// Update is called once per frame
	void Update () {
		if (movement)
		{
			transform.position = Vector3.MoveTowards (transform.position, target, speed);
		}
		if (transform.position == target) {
			movement = false;
			movement1 = true;
		}
		if (movement1) 
		{
			transform.position = Vector3.MoveTowards (transform.position, station.transform.position, speed);
		}
		if (transform.position == station.transform.position) {
			movement1 = false;
		}

	}


	void OnMouseDown()
	{
		if (gameObject.CompareTag ("legal")) {
			movement = true;
			Debug.Log ("mouse clicked on legal target");
			target = transform.position + buffor;
		}
	}


}