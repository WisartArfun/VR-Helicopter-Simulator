using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Local_Input : MonoBehaviour {

	private float h_Input;
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

	void Start () {
		controller_keyboard = GetComponent<Controller_Keyboard>();
		receiver_input_controller = receiver.GetComponent<Input_to_Movement>();
		checkpoint_movement = GetComponent<Checkpoints_Movement>();
		input_mode = new AllAroundInput();
		// receiver_input_controller.force = receiver_input_controller.gravity_amount * input_mode.gravity_times_force;
		Debug.Log(receiver_input_controller.force);
	}

	void Update () {
		h_Input = Input.GetAxis("Vertical");  //somehow the axis is inverted
		yInput = Input.GetAxis("Horizontal");

		forward_Input = Input.GetAxis("Forward");
		sideward_Input = Input.GetAxis("Sideward");

		if (Input.GetKeyDown(KeyCode.Joystick1Button0)) {
			if (locked) {
				locked = false;
			} else {
				locked = true;
			}
			locked_value = h_Input;
		}

		if (locked) {
			h_Input += locked_value;
		}
		receiver_input_controller.Vertical_Movement(input_mode.adapt_input(h_Input));

		if (Mathf.Abs(yInput) > 0.1f) {
			receiver_input_controller.Rotate(yInput);
		}

		if (Mathf.Abs(forward_Input) > 0.1f) {
			receiver_input_controller.Forward( forward_Input);
		} else {
			receiver_input_controller.Forward(0);
		}

		if (Mathf.Abs(sideward_Input) > 0.1f) {
			receiver_input_controller.Sideward(sideward_Input);
		} else {
			receiver_input_controller.Sideward(0);
		}

		if (Input.GetButton ("NextC")) {
			checkpoint_movement.change_checkpoint(1);
		} else if (Input.GetButton("PreviousC")) {
			checkpoint_movement.change_checkpoint(-1);
		}

		if (Input.GetButton("Reset")) {   //x joystick button 2
			receiver_input_controller.Reset();
		}

		if (controller_keyboard.m_State == Controller_Keyboard.eInputState.MouseKeyboard) {
		} else {
		}
	}
}