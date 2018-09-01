using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManaging : MonoBehaviour {
	
	ChangeScene scene_changer;

	int num = 0;

	void Start () {
		scene_changer = new ChangeScene();
	}

	public void change_scene(int scene) {
		scene_changer.change_scene(scene);
	}

	void Update() {
		if (Input.GetButtonDown("Reset") && num < 1) {
			change_scene(1);
			num++;
		}
	}
}
