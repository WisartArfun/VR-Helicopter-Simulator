using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints_Movement : MonoBehaviour {

	public List<Transform> checkpoints;
	public SceneData scene_data;
	int current_checkpoint = 0;
	Vector3 direction_to_checkpoint;
	public float speed = 8;
	int old_direction = 2;
	Transform target;
	int target_num = 1;

	int next_c = 1;
	int last_c = 0;

	void Start() {
		checkpoints = scene_data.controller_checkpoints;
	}

	public void change_checkpoint(int direction) {
		if (transform.position == checkpoints[next_c].position) {
			next_c++;
			last_c++;
			if (next_c >= checkpoints.Count) {
				next_c =0;
			}
			if (last_c >= checkpoints.Count) {
				last_c = 0;
			}
		} else if (transform.position == checkpoints[last_c].position) {
			next_c--;
			last_c--;
			if (next_c < 0) {
				next_c = checkpoints.Count - 1;
			}
			if (last_c < 0) {
				last_c = checkpoints.Count - 1;
			}
		}

		if (direction == 1) {
			transform.position = Vector3.MoveTowards(transform.position, checkpoints[next_c].position, speed * Time.deltaTime);
		} else {
			transform.position = Vector3.MoveTowards(transform.position, checkpoints[last_c].position, speed * Time.deltaTime);
		}
	}
}
