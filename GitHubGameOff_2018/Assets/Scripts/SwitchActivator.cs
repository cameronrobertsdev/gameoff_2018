using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivator : MonoBehaviour {

    Camera cam;

    bool useDown;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        RaycastHit hit;

        if (Input.GetAxisRaw("Use") == 1 && !useDown)
        {
            if (Physics.Raycast(ray, out hit))
            {
                //print(hit.transform.name);
                if (hit.transform.gameObject.tag == "Switch")
                {
                    HitSwitch(hit.transform.gameObject);

                }
            }
        }

        if (Input.GetAxisRaw("Use") == 0)
        {
            useDown = false;
        }

    }

    private void HitSwitch(GameObject switcheroo)
    {
        useDown = true;
        switcheroo.GetComponent<Switch>().on = !switcheroo.GetComponent<Switch>().on;
    }

}
