using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalHelicopterInput : NetworkBehaviour {

	public InputToMovement receiver;
	[SyncVar(hook="on_id_change")]
	public NetworkInstanceId receiver_id;

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
	}

	void FixedUpdate() {
		if (!hasAuthority) {
			return;
		}

		if (Input.GetKey(KeyCode.U)) {
			receiver.move_vertical(10f);
		}
	}
}
