using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour {
	
	float speed = 7;

	public Material[] playerMaterials;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckPressArrowButton ();
		CheckPressNumbersButton ();
	}

	void Move (float moveSpeed) {
		transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
	}

	void CheckPressArrowButton () {
		float newSpeed = speed * Time.deltaTime;
		if (Input.GetKey (KeyCode.LeftArrow))
			Move (-newSpeed);
		else if (Input.GetKey (KeyCode.RightArrow))
			Move (newSpeed);
	}

	void CheckPressNumbersButton () {
		if (Input.GetKey (KeyCode.Alpha1))
			ChangeColor (0);
		else if (Input.GetKey (KeyCode.Alpha2))
			ChangeColor (1);
		else if (Input.GetKey (KeyCode.Alpha3))
			ChangeColor (2);
		else if (Input.GetKey (KeyCode.Alpha4))
			ChangeColor (3);
	}

	void ChangeColor (int indexColor) {
		this.GetComponent<LineRenderer>().material = playerMaterials[indexColor]; 
	}
}
