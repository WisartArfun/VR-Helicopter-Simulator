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

	void Start () {
		controller_keyboard = GetComponent<Controller_Keyboard>();
		receiver_input_controller = receiver.GetComponent<Input_to_Movement>();
	}

	void FixedUpdate () {
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

		// if (Mathf.Abs(h_Input) > 0.1) {
		// if (h_Input > 0.1f) {
		if (locked) {
			h_Input += locked_value;
		}
		receiver_input_controller.Vertical_Movement(h_Input);
		// }

		Debug.Log(yInput);

		if (Mathf.Abs(yInput) > 0.1f) {
			receiver_input_controller.Rotate(yInput);
		}

		if (Mathf.Abs(forward_Input) > 0.1f) {
			receiver_input_controller.Forward(forward_Input);
		} else {
			receiver_input_controller.Forward(0);
		}

		if (Mathf.Abs(sideward_Input) > 0.1f) {
			receiver_input_controller.Sideward(sideward_Input);
		} else {
			receiver_input_controller.Sideward(0);
		}


		if (controller_keyboard.m_State == Controller_Keyboard.eInputState.MouseKeyboard) {
		} else {
		}
	}
}