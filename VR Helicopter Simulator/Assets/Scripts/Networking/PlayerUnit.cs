using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerUnit : NetworkBehaviour {

	public Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		if (!hasAuthority) {
			rb.AddForce(-Physics.gravity);
			return;
		}
	}
	
	void Update () {
		if (!hasAuthority) {
			// rb.addForce(25);
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
