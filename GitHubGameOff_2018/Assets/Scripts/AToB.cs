using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AToB : MonoBehaviour {
    //Rigidbody Refrence
    Rigidbody rigid;

    //This will be an empty game object used to define where the object will move to
    [SerializeField]
    Transform pointA;
    //This will be an empty game object used to define where the object will move to
    [SerializeField]
    Transform pointB;

    //determines wh
    [SerializeField]
    bool on;

    [SerializeField]
    bool aActive;
    [SerializeField]
    bool bActive;

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject triggerObject;

    [SerializeField]
    GameObject powerSource;

    Switch switchScript;
    Switch powerSwitch;

    private bool switchActivated;

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
        if (triggerObject != null)
        {
            switchScript = triggerObject.GetComponent<Switch>();
            switchActivated = true; 
        }

        if (powerSource.gameObject != null)
        {
            powerSwitch = powerSource.GetComponent<Switch>();
        }


    }

    private void Update()
    {
        if (switchActivated)
        {
            if (switchScript.on == true)
            {
                aActive = true;
                bActive = false;
            }
            else
            {
                bActive = true;
                aActive = false;
            }
        }

    }

    // FixedUpdate is called at a set rate
    void FixedUpdate () {
        if (on)
        {
            if (aActive)
            {
                if (Vector3.Distance(gameObject.transform.position, pointB.position) > 0.1)
                {
                    print(Vector3.Distance(gameObject.transform.position, pointB.position).ToString());
                    rigid.AddForce((pointB.position - gameObject.transform.position).normalized * speed);
                }
                else
                {
                    rigid.velocity = new Vector3(0, 0, 0);
                    if (!switchActivated)
                    {
                        bActive = true;
                        aActive = false;
                    }
                }
            }

            if (bActive)
            {
                if (Vector3.Distance(gameObject.transform.position, pointA.position) > 0.1)
                {
                    rigid.AddForce((pointA.position - gameObject.transform.position).normalized * speed);
                }
                else
                {
                    rigid.velocity = new Vector3(0, 0, 0);
                    if (!switchActivated)
                    {
                        bActive = false;
                        aActive = true;
                    }
                }
            }
        }
	}
}
