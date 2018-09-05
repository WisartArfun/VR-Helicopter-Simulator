using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionObject : NetworkBehaviour {

	public GameObject player_unit_prefab;
	public GameObject player_manager_prefab;

	[SyncVar(hook="on_player_name_change")]
	public string player_name = "Anonymous";

	void Start () {
		if (!isLocalPlayer) {
			return;
		}

		Cmd_spawn_unit();
	}

	void Update () {
		if (!hasAuthority) {
			return;
		}

		if (Input.GetKeyDown(KeyCode.S)) {
			Cmd_spawn_unit();
		}

		if (Input.GetKeyDown(KeyCode.Q)) {
			string n = "Quill" + Random.Range(1, 100);
			Cmd_change_player_name(n); 
		}
	}

	[Command]
	void Cmd_spawn_unit() {
		// var pm = Instantiate(player_manager_prefab);
		var pu = Instantiate(player_unit_prefab);

		NetworkServer.SpawnWithClientAuthority(pu, connectionToClient); 
		// NetworkServer.SpawnWithClientAuthority(pm, connectionToClient);

		// pm.GetComponent<Local_Helicopter_Input>().receiver_id = pu.GetComponent<NetworkIdentity>().netId;
		GameObject.FindWithTag("Player Manager").GetComponent<Local_Helicopter_Input_2>().Receiver_Id = pu.GetComponent<NetworkIdentity>().netId;
	}

	[Command]
	void Cmd_change_player_name(string n) {
		player_name = n;
		// Rpc_change_player_name(n);
	} 

	// [ClientRpc]
	// void Rpc_change_player_name(string n) {
	// 	player_name = n;
	// }

	void on_player_name_change(string n) {
		gameObject.name = "Player Connection Object [" + n + "]";
		player_name = n;
	}
}
