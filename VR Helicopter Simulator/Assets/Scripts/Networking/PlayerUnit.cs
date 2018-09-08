using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerUnit : NetworkBehaviour {
	
	void Update () {
		if (!hasAuthority) {
			return;
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			this.transform.Translate(0, 1, 0);
		}

		if (Input.GetKeyDown(KeyCode.D)) {
			Destroy(gameObject);
		}
	}
}
