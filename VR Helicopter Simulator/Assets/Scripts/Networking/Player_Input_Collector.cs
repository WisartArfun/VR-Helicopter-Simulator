using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Input_Collector : MonoBehaviour {

	// public List<Input_to_Movement> receiver;
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

	public List<Local_Helicopter_Input> input_list;

	void Start() {
		input_list.Clear();
	}

	void on_id_change(NetworkInstanceId id_new) {
		input_list.Add(ClientScene.FindLocalObject(id_new).GetComponentInChildren<Local_Helicopter_Input>());
	}

	void Update () {
		if (Input.GetKey(KeyCode.T)) {
			// receiver.move_horizontal(10f);
		} 

		if (Input.GetKeyDown(KeyCode.Space)) {
			foreach (var r in input_list) {
				r.translated_space();
			}
		}

		if (Input.GetKeyDown(KeyCode.D)) {
			foreach (var r in input_list) {
				r.translated_d();
			}
			input_list.Clear();
		}
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
