using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToMovement : MonoBehaviour {

	public void move_vertical(float force) {
		GetComponent<Rigidbody>().AddForce(transform.up * force * 1);
		Debug.Log("nice try");
		transform.Translate(0.1f, 0, 0);
	}

	public void move_horizontal(float force) {
		transform.Rotate(force * 1, 0, 0);
	}
}
