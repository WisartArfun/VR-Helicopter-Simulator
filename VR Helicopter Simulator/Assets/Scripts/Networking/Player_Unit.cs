using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Unit : NetworkBehaviour {

	// public Local_Helicopter_Input controller;
	// [SyncVar(hook="on_id_change")]
	// public NetworkInstanceId controller_id;

	// void on_id_change(NetworkInstanceId id_new) {
	// 	controller = ClientScene.FindLocalObject(id_new).GetComponent<Local_Helicopter_Input>();

	// 	if (!isLocalPlayer) {
	// 		return;
	// 	}

	// 	Cmd_set_controller();
	// }
 
	// [Command] 
	// void Cmd_set_controller() {
	// 	controller = ClientScene.FindLocalObject(controller_id).GetComponent<Local_Helicopter_Input>();
	// }

	// void Update () {
	// 	if (!hasAuthority) {
	// 		return;
	// 	}

	// 	if (Input.GetKeyDown(KeyCode.Space)) {
	// 		this.transform.Translate(0, 1, 0);
	// 	}

	// 	if (Input.GetKeyDown(KeyCode.D)) {
	// 		Destroy(gameObject);
	// 	}
	// }
}
