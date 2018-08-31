using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManaging : MonoBehaviour {
	
	ChangeScene scene_changer;
	void Start () {
		scene_changer = new ChangeScene();
	}

	public void change_scene(int scene) {
		scene_changer.change_scene(scene);
	}
}
