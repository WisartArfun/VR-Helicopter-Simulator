using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Local_Input : MonoBehaviour {

	private float v_Input;
	private float yInput;
	private float forward_Input;
	private float sideward_Input;

	public Controller_Keyboard controller_keyboard;
	public GameObject receiver;
	private Input_to_Movement receiver_input_controller;
	public bool locked;
	private float locked_value;
	private float end_value;

	Checkpoints_Movement checkpoint_movement;

	AllAroundInput input_mode;

	public bool floating;

	void Start () {
		controller_keyboard = GetComponent<Controller_Keyboard>();
		receiver_input_controller = receiver.GetComponent<Input_to_Movement>();
		checkpoint_movement = GetComponent<Checkpoints_Movement>();
		input_mode = new AllAroundInput();
		// receiver_input_controller.force = receiver_input_controller.gravity_amount * input_mode.gravity_times_force;
	}

	void Update () {
		horizontal_input(Input.GetAxis("Horizontal"), Time.deltaTime);

		forward_input(Input.GetAxis("Forward"));
		sideward_input(Input.GetAxis("Sideward"));

		change_controller_checkpoint(Input.GetButton ("NextC"), Input.GetButton("PreviousC"));

		if (Input.GetButton("Reset")) {
			reset_helicopter();
		}	

		if (Input.GetKeyDown(KeyCode.JoystickButton3)) {
			switch_floating();
		}		

		if (controller_keyboard.m_State == Controller_Keyboard.eInputState.MouseKeyboard) {
		} else {
		}
	}

	void FixedUpdate() {
		if (Input.GetKeyDown(KeyCode.Joystick6Button6)) {
			Debug.Log("6");
		} else if (Input.GetKeyDown(KeyCode.Joystick6Button7)) {
			Debug.Log("7");
		} else if (Input.GetKeyDown(KeyCode.Joystick6Button8)) {
			Debug.Log("8");
		} else if (Input.GetKeyDown(KeyCode.Joystick6Button9)) {
			Debug.Log("9");
		} else if (Input.GetKeyDown(KeyCode.Joystick6Button10)) {
			Debug.Log("10");
		} else if (Input.GetKeyDown(KeyCode.Joystick6Button11)) {
			Debug.Log("11");
		} 

		if (Input.GetKeyDown(KeyCode.Joystick1Button0)) {
			lock_force_value();
		}

		vertical_movement(Input.GetAxis("Vertical"), Time.fixedDeltaTime);
	}

	void horizontal_input(float input, float timestep) {
			// Debug.Log("k2 " + input);
		if (Mathf.Abs(input) > 0.1f) {
			receiver_input_controller.Rotate(input_mode.adapt_input(input) * timestep);
		}
	}

	void forward_input(float input) {
		// Debug.Log("k1 " + input);
		if (Mathf.Abs(input) > 0.1f) {
			receiver_input_controller.Forward(input);
		} else {
			receiver_input_controller.Forward(0);
		}
	}

	void sideward_input(float input) {
		// Debug.Log("k3 " + input);
		if (Mathf.Abs(input) > 0.1f) {
			// receiver_input_controller.Sideward(input_mode.adapt_input(input));
			receiver_input_controller.Sideward(input);
		} else {
			receiver_input_controller.Sideward(0);
		}
	}

	void change_controller_checkpoint(bool previous, bool next) {
		if (next) {
			checkpoint_movement.change_checkpoint(1);
		} else if (previous) {
			checkpoint_movement.change_checkpoint(-1);
		}
	}

	void reset_helicopter() {
		receiver_input_controller.Reset();
	}

	void switch_floating() {
		if (floating) {
			floating = false;
		} else {
			floating = true;
		}
	}

	void lock_force_value() {
		if (locked) {
			locked = false;
		} else {
			locked = true;
		}
		locked_value = v_Input;
	}

	void vertical_movement(float input, float timestep) {
		if (locked) {
			input += locked_value;
		}
		if (floating) {
			input += input_mode.flying_controlled;
		}
		// Debug.Log(input_mode.adapt_input(input) * timestep);
		receiver_input_controller.Vertical_Movement(input_mode.adapt_input(input) * timestep);
	}
}