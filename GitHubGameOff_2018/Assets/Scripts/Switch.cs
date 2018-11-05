using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public bool on;

    //I will use the color of the object to show the on state during prtotyping. This ought to be changed to an animator value for the final game.
    Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (on)
        {
            rend.material.color = Color.green;
        }
        else
        {
            rend.material.color = Color.red;
        }
		
	}
}
