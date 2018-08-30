using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSettings : MonoBehaviour {

	bool showing = false;
	public GameObject canavas;

	void Start() {
		if (showing) {

		} else {
			canavas.SetActive(false);
		}
		canavas.SetActive(true);
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.JoystickButton3)) {
			if (showing) {
				showing = false;
				canavas.SetActive(showing);
			} else {
				showing = true;
				canavas.SetActive(showing);
				Debug.Log("ajsdlfkjasl;kfaslkfjkslf");
			}
		}
	}
}
