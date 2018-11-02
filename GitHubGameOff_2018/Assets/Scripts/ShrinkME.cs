using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkME : MonoBehaviour {

    bool shrinking;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxisRaw("Fire2") == 1)
        {
            shrinking = true;
        }
        else
        {
            shrinking = false;
        }

        if (shrinking)
        {
            transform.localScale = new Vector3(transform.localScale.x + Input.GetAxis("Mouse Y") * Time.deltaTime, transform.localScale.y + Input.GetAxis("Mouse Y") * Time.deltaTime, transform.localScale.z + Input.GetAxis("Mouse Y") * Time.deltaTime);
        }
		
	}
}
