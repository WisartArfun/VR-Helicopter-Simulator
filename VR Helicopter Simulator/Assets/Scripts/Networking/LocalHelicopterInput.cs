using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalHelicopterInput : NetworkBehaviour {

	public InputToMovement receiver;
	[SyncVar(hook="on_id_change")]
	public NetworkInstanceId receiver_id;


	private float v_Input;
	private float yInput;
	private float forward_Input;
	private float sideward_Input;

	public Controller_Keyboard controller_keyboard;
	// public GameObject receiver;
	// private InputToMovement receiver_input_controller;
	public bool locked;
	private float locked_value;
	private float end_value;

	Checkpoints_Movement checkpoint_movement;

	AllAroundInput input_mode;

	public bool floating;

	public OpenSettings open_settings;

	void on_id_change(NetworkInstanceId id_new) {
		receiver = ClientScene.FindLocalObject(id_new).GetComponent<InputToMovement>();

		if (!isLocalPlayer) {
			return;
		}

		Cmd_set_receiver();
	}

	[Command] 
	void Cmd_set_receiver() {
		receiver = ClientScene.FindLocalObject(receiver_id).GetComponent<InputToMovement>();
	}

	void Update () {
		if (!hasAuthority) { 
			return;
		}

		if (Input.GetKey(KeyCode.T)) {
			receiver.move_horizontal(10f);
		} 

		horizontal_input(Input.GetAxis("Horizontal"), Time.deltaTime);

		forward_input(-Input.GetAxis("Forward"));
		sideward_input(-Input.GetAxis("Sideward"));
		Debug.Log(Input.GetAxis("Forward"));

		change_controller_checkpoint(Input.GetButton ("NextC"), Input.GetButton("PreviousC"));

		if (Input.GetButton("Reset")) {
			reset_helicopter();
		}	

		if (Input.GetButtonDown("Switch Floating")) {
			switch_floating();
		}

		if (Input.GetButtonDown("Open Pause Menu")) {
			open_settings.change_active();
		}	

		if (controller_keyboard.m_State == Controller_Keyboard.eInputState.MouseKeyboard) {
		} else {
		}
	}

	void FixedUpdate() {
		if (!hasAuthority) {
			return;
		}

		if (Input.GetKey(KeyCode.U)) {
			receiver.move_vertical(10f);
		}

		if (Input.GetKeyDown(KeyCode.Joystick1Button0)) {
			lock_force_value();
		}

		vertical_movement(Input.GetAxis("Vertical"), Time.fixedDeltaTime);
	}

	void Start () {
		controller_keyboard = GetComponent<Controller_Keyboard>();
		receiver = receiver.GetComponent<InputToMovement>();
		checkpoint_movement = GetComponent<Checkpoints_Movement>();
		input_mode = new AllAroundInput();
		// receiver_input_controller.force = receiver_input_controller.gravity_amount * input_mode.gravity_times_force;
	}

	void horizontal_input(float input, float timestep) {
		if (Mathf.Abs(input) > 0.1f) {
			receiver.Rotate(input_mode.adapt_input(input) * timestep);
		}
	}

	void forward_input(float input) {
		// Debug.Log("k1 " + input);
		if (Mathf.Abs(input) > 0.1f) {
			receiver.Forward(input);
		} else {
			receiver.Forward(0);
		}
	}

	void sideward_input(float input) {
		// Debug.Log("k3 " + input);
		if (Mathf.Abs(input) > 0.1f) {
			// receiver_input_controller.Sideward(input_mode.adapt_input(input));
			receiver.Sideward(input);
		} else {
			receiver.Sideward(0);
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
		receiver.Reset();
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
		receiver.Vertical_Movement(input_mode.adapt_input(input) * timestep);
	}
}
