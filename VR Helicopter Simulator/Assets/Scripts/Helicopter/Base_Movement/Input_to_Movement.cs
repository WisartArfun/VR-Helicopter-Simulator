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

	public float max_forward_rotation;
	public float rotation_speed_forward;
	public float max_forward_rotaiton_at_once;
	public float min_forward_rotation_at_once;
	private float target_rotation_forward;
	private float additional_rotation_forward;
	private float current_forward_rotation;

	private Vector3 new_sideward_rotation;
	public float sideward_rotation_max_amount = 300;
	private Quaternion sideward_rotation;

	public float max_sideward_rotation;
	public float rotation_speed_sideward;
	public float max_sideward_rotation_at_once;
	public float min_sideward_rotation_at_once;
	private float target_rotation_sideward;
	private float additional_rotation_sideward;
	private float current_sideward_rotation;
	
	void Start () {
		rb = GetComponent<Rigidbody>();
		helicopter = GetComponent<Transform>();
		Physics.gravity = new Vector3(0, -gravity_amount, 0);
		rotor_rotation = new Vector3(0, 0, 30);
	}

	public void Vertical_Movement(float amount) {
		var end_amount = amount * Time.deltaTime * force;
		if (Mathf.Abs(end_amount - gravity_amount) < 1f) {
			end_amount = gravity_amount;
		}
		rb.AddForce(end_amount * helicopter.up);
		rotor.Rotate(rotor_rotation * 0.55f);
	}

	public void Rotate(float amount) {
		rotation_amount = Quaternion.Euler(0, rotation_speed * amount * Time.deltaTime, 0);
		helicopter.rotation = rotation_amount * helicopter.rotation;
	}

	public void Forward(float amount) {
		// new_sideward_rotation.Set(sideward_rotation_max_amount * amount * Time.fixedDeltaTime - helicopter.rotation.eulerAngles.x,  	0, 0);
		// helicopter.Rotate(new_sideward_rotation, Space.Self);

		target_rotation_forward = max_forward_rotation * amount;
		
		var new_rot_f = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(target_rotation_forward, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z), Time.deltaTime * rotation_speed_forward);

		helicopter.rotation = new_rot_f;
	}
		

	public void Sideward(float amount) {
		// new_forward_rotation.Set(0, 0, forward_rotation_max_amount * amount * Time.deltaTime - helicopter.rotation.eulerAngles.z);
		// helicopter.Rotate(new_forward_rotation, Space.Self);

		target_rotation_sideward = max_sideward_rotation * amount;
		
		var new_rot_s = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, target_rotation_sideward), Time.deltaTime * rotation_speed_sideward);

		helicopter.rotation = new_rot_s;
	}
}