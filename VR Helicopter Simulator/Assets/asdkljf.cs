using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class asdkljf : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// if (!hasAuthority) {
		// 	return;
		// }
		
		if (Input.GetButtonDown("Space")) {
			transform.Translate(1, 0, 0);
			Debug.Log("askljdfklsjkfa;klsdfjkl;a");
		}
		Debug.Log("askljdfklsjkfa;klsdfjkl;a");
	}
}
