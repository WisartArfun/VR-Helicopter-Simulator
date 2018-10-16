using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Checkpoints_Helicopter_Management : NetworkBehaviour {

	public List<Transform> checkpoints;

	int current_checkpoint = 0;

	public Material target;
	public Material done;
	public Material undone;

	public float timer = 0;
	private float frames = 0;

	public Text current_timer_text;
	public Text record_text;
	public Text last_run_text;

	void Start() {
		if (!hasAuthority) {
			return;
		}
		var checkpoints_go = GameObject.FindGameObjectsWithTag("Helicopter Checkpoint");
		foreach (var g in checkpoints_go) {
			checkpoints.Add(g.transform);
			g.GetComponent<MeshRenderer>().material = undone;
		}
		checkpoints[current_checkpoint].GetComponent<MeshRenderer>().material = target; 
		record_text.GetComponent<Text>().text = System.Convert.ToString(PlayerPrefs.GetFloat("record", float.PositiveInfinity));
		last_run_text.GetComponent<Text>().text = System.Convert.ToString(PlayerPrefs.GetFloat("last_run", float.PositiveInfinity));
		Debug.Log("hello");
		Debug.Log(GetComponentsInChildren<Transform>());
		// foreach (var t in GetComponentsInChildren<Transform>()) {
		// 	Debug.Log(t);
		// 	// checkpoints.Add();
		// }
	}

	void Update() {
		if (!hasAuthority) {
			return;
		}
		if (frames%15 == 0) {
			var d = Vector3.Distance(transform.position, checkpoints[current_checkpoint].position);
			Debug.Log(d);
			if (d < 2.5f) {
				checkpoints[current_checkpoint].GetComponent<MeshRenderer>().material = done;
				Debug.Log("checkpoint " + current_checkpoint + " completed");
				current_checkpoint++;
				if (current_checkpoint >= checkpoints.Count) {
					Debug.Log("you have completed the parkour in 	" + timer + "	seconds - congrats");
					if (timer < PlayerPrefs.GetFloat("record", float.PositiveInfinity)) {
						PlayerPrefs.SetFloat("record", timer);
						record_text.GetComponent<Text>().text = System.Convert.ToString(timer);
					}
					PlayerPrefs.SetFloat("last_run", timer);
					last_run_text.GetComponent<Text>().text = System.Convert.ToString(timer);
					current_checkpoint = 0;
					reset_timer();
				}
				checkpoints[current_checkpoint].GetComponent<MeshRenderer>().material = target;
			}
			frames = 0;
			current_timer_text.text = System.Convert.ToString(timer);
		}
		// if (frames%50 == 0) {

		// }
		// if (frames%50 == 0 && frames%15 == 0) {
		// 	frames = 0;
		// }
		timer += Time.fixedDeltaTime;
		frames++;
	}

	public void reset_timer() {
		timer = 0;
	}
}
