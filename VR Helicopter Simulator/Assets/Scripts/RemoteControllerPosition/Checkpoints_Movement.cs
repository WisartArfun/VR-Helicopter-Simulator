using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints_Movement : MonoBehaviour {

	public List<Transform> checkpoints;
	
	int current_checkpoint = 0;
	Vector3 direction_to_checkpoint;
	public float speed = 5;
	int old_direction = 2;
	Transform target;
	int target_num;
	 
	public void change_checkpoint(int direction) {
		if (direction != old_direction) {
			change_direction(direction);
		}

		if ((transform.position - target.position).magnitude <= 0.1f) {
			new_direction(direction);
		}

		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}

	void change_direction(int direction) {
		// direction_to_checkpoint = checkpoints[current_checkpoint].position - checkpoints[current_checkpoint + direction].position;
		if (target_num == direction) {
			target = checkpoints[current_checkpoint + direction];
		} else {
			target = checkpoints[current_checkpoint];
		}
	}

	void new_direction(int direction) {
		target_num = direction;
		if (target_num == 1) {
			current_checkpoint += 1;
		}
		if (current_checkpoint >= checkpoints.Count) {
			current_checkpoint = 0;
		} else if (current_checkpoint < 0) {
			current_checkpoint = checkpoints.Count - 1;
		}
		target = checkpoints[current_checkpoint + direction];
	}
}
