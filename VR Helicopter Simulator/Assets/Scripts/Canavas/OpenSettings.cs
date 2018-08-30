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
	}

	public void change_active() {
		if (showing) {
			showing = false;
			canavas.SetActive(showing);
		} else {
			showing = true;
			canavas.SetActive(showing);
		}
	}

	public void game_resume() {
		showing = false;
		canavas.SetActive(showing);
	}

	public void game_reset() {

	}

	public void game_exit() {

	}
}
