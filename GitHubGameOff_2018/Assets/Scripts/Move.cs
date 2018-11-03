using System.Collections;
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

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {


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

    private void FixedUpdate()
    {
        if (grounded && jump == 1)
        {
            rigid.velocity = new Vector3(rigid.velocity.x, jumpStrength, rigid.velocity.z);
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

        if (transform.InverseTransformVector(rigid.velocity).z > maxVelocity)
        {
            rigid.AddForce(transform.forward * -transform.InverseTransformVector(rigid.velocity).z * 10);
        }
        if (transform.InverseTransformVector(rigid.velocity).z < -maxVelocity)
        {
            rigid.AddForce(transform.forward * -transform.InverseTransformVector(rigid.velocity).z * 10);
        }

        if (transform.InverseTransformVector(rigid.velocity).x > maxVelocity)
        {
            rigid.AddForce(transform.right * -transform.InverseTransformVector(rigid.velocity).x * 10);
        }
        if (transform.InverseTransformVector(rigid.velocity).x < -maxVelocity)
        {
            rigid.AddForce(transform.right * -transform.InverseTransformVector(rigid.velocity).x * 10);
        }

    }

}
