
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAroundInput : InputMode {
	float a = - 0.145238f;
	float b = 1.49008f;
	float c = -0.3f;
	float d = 0.0361111f;

	// public AllAroundInput() {
	// 	// gravity_times_force = 120;
	// }

	public float flying_controlled =  0.596f;


	// float a = 0.124304f;
	// float b = 0.616127f;
	// float c = 0.277593f;
	// float d = -0.0359924f;

	// public float flying_controlled = 2.6225f / 6f;

	// public AllAroundInput() {
	// 	// gravity_times_force = 120;
	// }

	public override float adapt_input(float input) {
		var x = input * 6;
		return (a + b * x + c * x* x + d * x * x * x)/ 6; /// /6
	}
	
}
