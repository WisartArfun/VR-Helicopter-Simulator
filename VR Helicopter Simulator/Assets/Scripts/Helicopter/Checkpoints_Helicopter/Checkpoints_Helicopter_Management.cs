using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoints_Helicopter_Management : MonoBehaviour {

	public List<Transform> checkpoints;

	int current_checkpoint = 0;

	public Material target;
	public Material done;

	public float timer = 0;
	private float frames = 0;

	public Text current_timer_text;
	public Text record_text;
	public Text last_run_text;

	void Start() {
		checkpoints[current_checkpoint].GetComponent<MeshRenderer>().material = target;
		record_text.GetComponent<Text>().text = System.Convert.ToString(PlayerPrefs.GetFloat("record", float.PositiveInfinity));
		last_run_text.GetComponent<Text>().text = System.Convert.ToString(PlayerPrefs.GetFloat("last_run", float.PositiveInfinity));
	}

	void Update() {
		if (frames >= 15) {
			var d = Vector3.Distance(transform.position, checkpoints[current_checkpoint].position);
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
		timer += Time.fixedDeltaTime;
		frames++;
	}

	public void reset_timer() {
		timer = 0;
	}
}
