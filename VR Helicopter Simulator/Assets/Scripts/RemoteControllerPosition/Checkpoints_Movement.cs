using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints_Movement : MonoBehaviour {

	// public List<Transform> checkpoints;
	
	// int current_checkpoint = 0;
	// Vector3 direction_to_checkpoint;
	// public float speed = 8;
	// int old_direction = 2;
	// Transform target;
	// int target_num = 1;
	 
	// // public void change_checkpoint(int direction) {
	// // 	if (direction != old_direction) {
	// // 		change_direction(direction);
	// // 		old_direction = direction;
	// // 	}

	// // 	if ((transform.position - target.position).magnitude <= 0.1f) {
	// // 		new_direction(direction);
	// // 	}

	// // 	transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	// // }

	// // void change_direction(int direction) {
	// // 	// direction_to_checkpoint = checkpoints[current_checkpoint].position - checkpoints[current_checkpoint + direction].position;
	// // 	if (target_num == direction) {
	// // 		if (current_checkpoint + direction >= checkpoints.Count) {
	// // 			target = checkpoints[0];
	// // 		} else if (current_checkpoint + direction < 0) {
	// // 			target = checkpoints[checkpoints.Count-1];
	// // 		} else {
	// // 			target = checkpoints[current_checkpoint + direction];
	// // 		}
	// // 	} else {
	// // 		target = checkpoints[current_checkpoint];
	// // 	}
	// // }

	// // void new_direction(int direction) {
	// // 	target_num = direction;
	// // 	if (target_num == 1) {
	// // 		if (checkpoints[current_checkpoint].position == transform.position) {
	// // 		} else {
	// // 			current_checkpoint += 1;
	// // 		}
	// // 	} else if (checkpoints[current_checkpoint].position == transform.position) {
	// // 	} else {
	// // 		current_checkpoint -= 1;
	// // 	}
	// // 	if (current_checkpoint >= checkpoints.Count) {
	// // 		current_checkpoint = 0;
	// // 	} else if (current_checkpoint < 0) {
	// // 		current_checkpoint = checkpoints.Count - 1;
	// // 	}
	// // 	if (current_checkpoint + direction >= checkpoints.Count) {
	// // 		target = checkpoints[0];
	// // 	} else if (current_checkpoint + direction < 0) {
	// // 		target = checkpoints[checkpoints.Count-1];
	// // 	} else {
	// // 		target = checkpoints[current_checkpoint + direction];
	// // 	}
	// // }

	// int next_c = 1;
	// int last_c = 0;

	// public void change_checkpoint(int direction) {
	// 	if (transform.position == checkpoints[next_c].position) {
	// 		next_c++;
	// 		last_c++;
	// 		if (next_c >= checkpoints.Count) {
	// 			next_c =0;
	// 		}
	// 		if (last_c >= checkpoints.Count) {
	// 			last_c = 0;
	// 		}
	// 	} else if (transform.position == checkpoints[last_c].position) {
	// 		next_c--;
	// 		last_c--;
	// 		if (next_c < 0) {
	// 			next_c = checkpoints.Count - 1;
	// 		}
	// 		if (last_c < 0) {
	// 			last_c = checkpoints.Count - 1;
	// 		}
	// 	}

	// 	if (direction == 1) {
	// 		transform.position = Vector3.MoveTowards(transform.position, checkpoints[next_c].position, speed * Time.deltaTime);
	// 	} else {
	// 		transform.position = Vector3.MoveTowards(transform.position, checkpoints[last_c].position, speed * Time.deltaTime);
	// 	}
	// }
}
