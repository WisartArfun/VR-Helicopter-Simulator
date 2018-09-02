using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerData : NetworkBehaviour {

	public string a_name;
	public GameObject helicopter;
	public GameObject helicopter_instance;
	public Transform spawn_pos;
	public GameObject myPlayerUnit;

	void Start () {
		if (!isLocalPlayer) {
			return;
		}

		Cmd_spawn_my_unit();
	}

	[Command]
	void Cmd_spawn_my_unit() {
		helicopter_instance = Instantiate(helicopter, spawn_pos, true) as GameObject;
		// helicopter_instance.transform.SetParent(transform);

		// helicopter_instance.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);

		myPlayerUnit = helicopter_instance;

		NetworkServer.SpawnWithClientAuthority(helicopter_instance, connectionToClient);
	}

	[Command]
	void move_my_unit() {
		if (myPlayerUnit == null) {
			return;
		}
		myPlayerUnit.transform.Translate(1, 0, 0);
	}
}
