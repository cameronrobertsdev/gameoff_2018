using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {


    float moveHori;
    float moveVert;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        moveHori = Input.GetAxis("Horizontal");
        moveVert = Input.GetAxis("Vertical");
		
	}
}
