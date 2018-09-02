using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	public string a_name;
	public GameObject helicopter;
	public GameObject helicopter_instance;
	public Transform spawn_pos;

	void Start () {
		helicopter_instance = Instantiate(helicopter, spawn_pos, true) as GameObject;
		helicopter_instance.transform.SetParent(transform);
		Debug.Log("working?");
	}
}
