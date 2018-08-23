using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAroundInput : InputMode {
	float a = - 0.145238f;
	float b = 1.49008f;
	float c = -0.3f;
	float d = 0.0361111f;

	public AllAroundInput() {
		// gravity_times_force = 120;
	}

	public override float adapt_input(float input) {
		return a + b * input + c * input* input + d * input * input * input / 6;
	}
	
}
