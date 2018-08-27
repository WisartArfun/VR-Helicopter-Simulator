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

	public float max_forward_rotation;
	public float rotation_speed_forward;
	private float target_rotation_forward;

	public float max_sideward_rotation;
	public float rotation_speed_sideward;
	private float target_rotation_sideward;

	public Transform start_pos;

	void Start () {
		rb = GetComponent<Rigidbody>();
		helicopter = GetComponent<Transform>();
		Physics.gravity = new Vector3(0, -gravity_amount, 0);
		rotor_rotation = new Vector3(0, 0, 30);
		force =  gravity_amount / (0.5f * Time.fixedDeltaTime);
	}

	public void Vertical_Movement(float amount) {
		var end_amount = 0f;;
		if (Mathf.Abs(amount-0.5f) < 0.05f) {
			// end_amount = gravity_amount * Time.deltaTime / Time.fixedDeltaTime;\
			end_amount = gravity_amount/ Time.fixedDeltaTime;
		} else {
			// end_amount = amount * Time.deltaTime * force;
			end_amount = amount * force;
		}

		rb.AddForce(end_amount * helicopter.up);
		rotor.Rotate(rotor_rotation * 4.55f);
	}

	public void Rotate(float amount) {
		// rotation_amount = Quaternion.Euler(0, rotation_speed * amount * Time.deltaTime, 0);
		rotation_amount = Quaternion.Euler(0, rotation_speed * amount, 0);
		helicopter.rotation = rotation_amount * helicopter.rotation;
	}

	public void Forward(float amount) {
		target_rotation_forward = max_forward_rotation * amount;
		
		// var new_rot_f = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(target_rotation_forward, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z), Time.deltaTime * rotation_speed_forward);
		var new_rot_f = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(target_rotation_forward, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z), rotation_speed_forward);

		helicopter.rotation = new_rot_f;
	}
		

	public void Sideward(float amount) {
		target_rotation_sideward = max_sideward_rotation * amount;
		
		// var new_rot_s = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, target_rotation_sideward), Time.deltaTime * rotation_speed_sideward);
		var new_rot_s = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, target_rotation_sideward), rotation_speed_sideward);

		helicopter.rotation = new_rot_s;
	}

	public void Reset() {
		helicopter.position = start_pos.position;
		helicopter.rotation = start_pos.rotation;
	}
}