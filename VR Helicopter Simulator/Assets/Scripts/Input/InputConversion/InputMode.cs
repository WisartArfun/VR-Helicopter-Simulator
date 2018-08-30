using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputMode : MonoBehaviour {

    public float gravity_times_force;

    public string a_name;
    	
    public abstract float adapt_input(float input);

}
