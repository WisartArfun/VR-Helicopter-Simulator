using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints_Helicopter_Management : MonoBehaviour {

	public List<Transform> checkpoints;

	int current_checkpoint = 0;

	public Material target;
	public Material done;

	public float timer = 0;
	private float frames = 0;

	void Start() {
		checkpoints[current_checkpoint].GetComponent<MeshRenderer>().material = target;
	}

	void FixedUpdate() {
		if (frames >= 15) {
			var d = Vector3.Distance(transform.position, checkpoints[current_checkpoint].position);
			if (d < 2.5f) {
				checkpoints[current_checkpoint].GetComponent<MeshRenderer>().material = done;
				Debug.Log("checkpoint " + current_checkpoint + " completed");
				current_checkpoint++;
				if (current_checkpoint >= checkpoints.Count) {
					Debug.Log("you have completed the parkour in 	" + timer + "	seconds - congrats");
					current_checkpoint = 0;
					timer = 0;
				}
				checkpoints[current_checkpoint].GetComponent<MeshRenderer>().material = target;
			}
			frames = 0;
		}
		timer += Time.fixedDeltaTime;
		frames++;
	}
}
