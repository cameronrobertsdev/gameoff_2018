using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {


    float mouseX;
    float mouseY;

    public float xSensitivity;
    public float ySensitivity;

    [SerializeField]
    bool useXAxis;
    [SerializeField]
    bool useYAxis;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (Input.GetAxisRaw("Fire1") == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
	}

    private void FixedUpdate()
    {
        if (useXAxis)
        {
            transform.Rotate(Vector3.up * mouseX * xSensitivity);
        }

        if (useYAxis)
        {
            transform.Rotate(-Vector3.right * mouseY * ySensitivity);
        }
    }
}
