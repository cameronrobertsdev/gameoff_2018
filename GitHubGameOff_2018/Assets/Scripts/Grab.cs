using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {

    public bool grabbing = false;

    bool grabbed;

    Rigidbody currentObj;

    FixedJoint hand;

	// Use this for initialization
	void Start () {
        hand = GetComponentInChildren<FixedJoint>();
	}
	
	// Update is called once per frame
	void Update () {

        //called when "E" key is pressed
        if (Input.GetAxisRaw("Grab") == 1 && !grabbing)
        {
            RaycastHit hit;

            //raycast
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5f))
            {
                //If it hits an object the object becomes the 
                if (hit.transform.gameObject.tag == "Object" && hit.transform.gameObject.GetComponent<Rigidbody>().mass <= 1)
                {
                    grabbing = true;
                    currentObj = hit.transform.gameObject.GetComponent<Rigidbody>();
                    currentObj.transform.position = hand.transform.position;
                    hand.connectedBody = currentObj;
                }
            }
        }

        if (Input.GetAxisRaw("Grab") == 0 && grabbing)
        {
            grabbed = true;
        }

        if (Input.GetAxisRaw("Grab") == 1 && grabbed)
        {
            currentObj = null;
            hand.connectedBody = null;
            grabbing = false;
            grabbed = false;
            
        }

        if (Input.GetAxisRaw("Fire1") == 1 && grabbed)
        {
            hand.connectedBody = null;
            currentObj.AddForce(Camera.main.transform.forward * 500);
            currentObj = null;
            grabbing = false;
            grabbed = false;

        }
    }
}
