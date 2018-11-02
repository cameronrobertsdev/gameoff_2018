using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    float force;

	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);

        Destroy(gameObject, 3);
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Add in remove health script
            Destroy(gameObject);
        }
    }

}
