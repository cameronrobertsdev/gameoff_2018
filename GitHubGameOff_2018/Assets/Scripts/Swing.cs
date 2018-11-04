using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour {

    [SerializeField]
    Transform target;

    SpringJoint rope;

    [SerializeField]
    LineRenderer line;


    bool fire2Down = false;

    bool swinging;


	// Use this for initialization
	void Start () {
        rope = gameObject.GetComponent<SpringJoint>();
	}
	
	// Update is called once per frame
	void Update () {


        print(swinging);

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        RaycastHit hit;

        if (Input.GetAxisRaw("Fire2") == 1 && !fire2Down)
        {
            fire2Down = true;

            if (!swinging)
            { 
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag == "Wall")
                    {
                        target.position = hit.point;
                        rope.spring = 100;
                        swinging = true;
                    }
                }
            }
        }

        if (swinging)
        {
            line.enabled = true;

            if (Vector3.Distance(target.position, transform.position) < 2)
            {
                swinging = false;
            }

            if (Input.GetAxisRaw("Fire1") == 1 && !fire2Down)
            {
                swinging = false;
            }
        }

        if (!swinging)
        {
            line.enabled = false;
            rope.spring = 0;
        }

        if (Input.GetAxisRaw("Fire2") == 0)
        {
            fire2Down = false;
        }

        line.SetPosition(0,target.position);
        line.SetPosition(1, transform.position);

	}
}
