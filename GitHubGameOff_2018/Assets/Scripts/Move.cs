﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    Rigidbody rigid;
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpStrength;

    [SerializeField]
    float maxVelocity;

    float forward;
    float right;
    [SerializeField]
    LayerMask groundLayerMask;

    bool grounded;

    float jump;

    bool onLift;

    Rigidbody liftRigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

       // print("Player Velocity = " + rigid.velocity.magnitude.ToString());


        if (rigid.velocity.magnitude > maxVelocity * 10)
        {
            rigid.drag = 10000;
        }
        else
        {
            rigid.drag = 0;
        }

        if (gameObject.tag == "Player1")
        {
            forward = Input.GetAxis("Vertical");
            right = Input.GetAxis("Horizontal");
            jump = Input.GetAxisRaw("Jump");
        }
        if (gameObject.tag == "Player2")
        {
            forward = Input.GetAxis("VerticalP2");
            right = Input.GetAxis("HorizontalP2");
            jump = Input.GetAxisRaw("JumpP2");
        }

        RaycastHit groundHit;
        if (Physics.Raycast(transform.position, -transform.up, out groundHit, 1.1f, groundLayerMask))
        {
            grounded = true;
            print("grounded");



        }
        else
        {
            grounded = false;
            print("In Air");
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "Lift")
        {
            onLift = true;

            liftRigid = collision.transform.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.name == "Lift")
        {
            onLift = false;
        }
    }

    private void FixedUpdate()
    {
        if (grounded && jump == 1)
        {
            rigid.velocity = new Vector3(rigid.velocity.x, jumpStrength, rigid.velocity.z);
        }

        if (onLift)
        {
            rigid.velocity = rigid.velocity + liftRigid.velocity;
        }

        if (forward > 0.1f || forward < -0.1)
        {
            rigid.AddForce(transform.forward * forward * speed);
            if (forward > 0.1 && transform.InverseTransformDirection(rigid.velocity).z < 0.1f)
            {
                rigid.AddForce(transform.forward * forward * speed * 2);
            }
            if (forward < -0.1 && transform.InverseTransformDirection(rigid.velocity).z > -0.1f)
            {
                rigid.AddForce(transform.forward * forward * speed * 2);
            }
        }
        if (right > 0.1f || right < -0.1)
        {
            rigid.AddForce(transform.right * right * speed);
            if (right > 0.1 && transform.InverseTransformDirection(rigid.velocity).x < 0.1f)
            {
                rigid.AddForce(transform.right * right * speed * 2);
            }
            if (right < -0.1 && transform.InverseTransformDirection(rigid.velocity).x > -0.1f)
            {
                rigid.AddForce(transform.right * right * speed * 2);
            }
        }

        if (right == 0)
        {
            rigid.AddForce(transform.right * -transform.InverseTransformVector(rigid.velocity).x * 10);
        }
        if (forward == 0)
        {
            rigid.AddForce(transform.forward * -transform.InverseTransformVector(rigid.velocity).z * 10);
        }

        if (transform.InverseTransformVector(rigid.velocity).z > maxVelocity && !onLift)
        {
            rigid.AddForce(transform.forward * -transform.InverseTransformVector(rigid.velocity).z * 10);
        }
        if (transform.InverseTransformVector(rigid.velocity).z < -maxVelocity && !onLift)
        {
            rigid.AddForce(transform.forward * -transform.InverseTransformVector(rigid.velocity).z * 10);
        }

        if (transform.InverseTransformVector(rigid.velocity).x > maxVelocity && !onLift)
        {
            rigid.AddForce(transform.right * -transform.InverseTransformVector(rigid.velocity).x * 10);
        }
        if (transform.InverseTransformVector(rigid.velocity).x < -maxVelocity && !onLift)
        {
            rigid.AddForce(transform.right * -transform.InverseTransformVector(rigid.velocity).x * 10);
        }

    }

}
