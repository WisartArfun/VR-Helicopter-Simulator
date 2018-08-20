using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_to_Movement : MonoBehaviour {

	private Rigidbody rb;
	private Transform helicopter;
	public Transform rotor;
	private Vector3 rotor_rotation;
	public float force = 5;
	
	public float gravity_amount = 10.0f;

	private Quaternion rotation_amount;
	public float rotation_speed = 100;

	private Vector3 new_forward_rotation;
	public float forward_rotation_max_amount = 300;
	private Quaternion forward_rotation;

	private Vector3 new_sideward_rotation;
	public float sideward_rotation_max_amount = 300;
	private Quaternion sideward_rotation;
	
	void Start () {
		rb = GetComponent<Rigidbody>();
		helicopter = GetComponent<Transform>();
		Physics.gravity = new Vector3(0, -gravity_amount, 0);
		rotor_rotation = new Vector3(0, 0, 30);
	}

	public void Vertical_Movement(float amount) {
		var end_amount = amount * Time.fixedDeltaTime * force;
		if (Mathf.Abs(end_amount - gravity_amount) < 1f) {
			end_amount = gravity_amount;
		}
		rb.AddForce(end_amount * helicopter.up);
		// var new_rotation = rotor.rotation;
		// new_rotation.y += 0.1f;
		// rotor.rotation = new_rotation;
		rotor.Rotate(rotor_rotation * 1);
	}

	public void Rotate(float amount) {
		rotation_amount = Quaternion.Euler(0, rotation_speed * amount * Time.fixedDeltaTime, 0);
		helicopter.rotation = rotation_amount * helicopter.rotation;
	}

	public void Forward(float amount) {
		// new_forward_rotation.Set(0, 0, forward_rotation_max_amount * amount * Time.fixedDeltaTime - helicopter.rotation.eulerAngles.z);
		// helicopter.Rotate(new_forward_rotation, Space.Self);

		// new_forward_rotation.Set(0, 0, (forward_rotation_max_amount * amount * Time.fixedDeltaTime - helicopter.rotation.eulerAngles.z) * 0.1f);
		// helicopter.Rotate(new_forward_rotation, Space.Self);

		// new_forward_rotation.Set(0, 0, forward_rotation_max_amount * amount * Time.fixedDeltaTime - helicopter.rotation.eulerAngles.z);
		// // helicopter.Rotate(new_forward_rotation, Space.Self);
		// transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, Quaternion.Euler(new_forward_rotation), 0.1f);

		// new_forward_rotation.Set(0, 0, forward_rotation_max_amount * amount * Time.fixedDeltaTime - helicopter.rotation.eulerAngles.z);
		// // helicopter.Rotate(new_forward_rotation, Space.Self);
		// transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, Quaternion.Euler(new_forward_rotation), 0.1f);

		new_sideward_rotation.Set(sideward_rotation_max_amount * amount * Time.fixedDeltaTime - helicopter.rotation.eulerAngles.x,  	0, 0);
		helicopter.Rotate(new_sideward_rotation, Space.Self);

		// new_sideward_rotation.Set(0, 	sideward_rotation_max_amount * amount * Time.fixedDeltaTime - helicopter.rotation.eulerAngles.x, 0);
		// helicopter.Rotate(new_sideward_rotation, Space.Self);
		// transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, Quaternion.Euler(new_forward_rotation), 0.1f);
	}

	public void Sideward(float amount) {
		new_forward_rotation.Set(0, 0, forward_rotation_max_amount * amount * Time.fixedDeltaTime - helicopter.rotation.eulerAngles.z);
		helicopter.Rotate(new_forward_rotation, Space.Self);
	}
}