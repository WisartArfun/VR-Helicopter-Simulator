using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Local_Helicopter_Input : NetworkBehaviour {
 
	public Input_to_Movement receiver;
	[SyncVar(hook="on_id_change")]
	public NetworkInstanceId receiver_id;

	void on_id_change(NetworkInstanceId id_new) {
		receiver = ClientScene.FindLocalObject(id_new).GetComponentInChildren<Input_to_Movement>();

		Debug.Log("kas;dlfaslkdfsdklfj;la");

		if (!isLocalPlayer) { 
			return;
		}

		Cmd_set_receiver();
	}

	[Command] 
	void Cmd_set_receiver() {
		receiver = ClientScene.FindLocalObject(receiver_id).GetComponentInChildren<Input_to_Movement>();
		Debug.Log(receiver);
		// receiver.controller_id = GetComponent<NetworkIdentity>().netId;
	}

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
			// receiver.transform.Translate(0, 1, 0);
		}

		if (Input.GetKeyDown(KeyCode.D)) {
			// Destroy(receiver.GetComponent<GameObject>());
			// Destroy(gameObject);
		}
	}
	
	public void translated_space() {
		receiver.transform.Translate(0, 1, 0);
	}

	public void translated_d() {
		Destroy(receiver.transform.root.gameObject);
		Destroy(gameObject);
	}

	void FixedUpdate() {
		if (!hasAuthority) {
			return;
		}

		if (Input.GetKey(KeyCode.U)) {
			// receiver.move_vertical(10f);
		}
	}
}
