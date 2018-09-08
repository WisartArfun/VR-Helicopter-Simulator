using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Local_Helicopter_Input_2 : NetworkBehaviour {

	public List<Input_to_Movement> receiver;
	// [SyncVar(hook="on_id_change")]
	public NetworkInstanceId receiver_id;
	public NetworkInstanceId Receiver_Id {
		set {
			receiver_id = value;
			on_id_change(receiver_id);
		}
		get {
			return receiver_id;
		}
	}

	void Start() {
		// Cmd_destroy_list();
		destroy_list();
	}

	void on_id_change(NetworkInstanceId id_new) {
		// receiver.Add(ClientScene.FindLocalObject(id_new).GetComponentInChildren<Input_to_Movement>());
		receiver.Add(ClientScene.FindLocalObject(id_new).GetComponentInChildren<Input_to_Movement>());

		// if (!isLocalPlayer) {
		// 	return;
		// }

		// Cmd_set_receiver();
	}

	// [Command] 
	// void Cmd_set_receiver() {
	// 	// var new_input_to_movement = ClientScene.FindLocalObject(receiver_id).GetComponentInChildren<Input_to_Movement>();
	// 	var new_input_to_movement = ClientScene.FindLocalObject(receiver_id).GetComponentInChildren<Input_to_Movement>();
		
	// 	// receiver.Add(new_input_to_movement);
		
	// 	// new_input_to_movement.controller_id = GetComponent<NetworkIdentity>().netId;
	// }

	void Update () {
		if (!hasAuthority) {
			return;
		}

		if (Input.GetKey(KeyCode.T)) {
			// receiver.move_horizontal(10f);
		} 

		// if (Input.GetKeyDown(KeyCode.D)) {
		// 	Destroy(receiver);
		// 	// and unit
		// }

		// if (!hasAuthority) {
		// 	return;
		// }

		if (Input.GetKeyDown(KeyCode.Space)) {
			foreach (var r in receiver) {
				r.transform.Translate(0, 1, 0);
			}
		}

		if (Input.GetKeyDown(KeyCode.D)) {
			// Cmd_destroy_list();
			destroy_list();
		}
	}

	[Command]
	void Cmd_destroy_list() {
		foreach (var r in receiver) {
			r.self_destruct();
		}
		receiver.Clear();
	}

	void destroy_list() {
		foreach (var r in receiver) {
			r.self_destruct();
		}
		receiver.Clear();
	}

	void FixedUpdate() {
		// if (!hasAuthority) {
		// 	return;
		// }

		if (Input.GetKey(KeyCode.U)) {
			// receiver.move_vertical(10f);
		}
	}
}
