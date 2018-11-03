using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    [SerializeField]
    Transform target;

    [SerializeField]
    string tagForTarget;

    bool aware;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float fireRate;

    [SerializeField]
    Transform barrelEnd;

	// Use this for initialization
	void Start () {
        StartCoroutine(FireShots());

	}
	
	// Update is called once per frame
	void Update () {
        if (aware)
        {
            transform.LookAt(target);
        }

        print(aware);

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == tagForTarget)
        {
            target = other.transform;
            aware = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.tag == tagForTarget)
        {
            aware = false;
        }
    }

    IEnumerator FireShots()
    {
        while (true)
        {
            if (aware)
            {
                GameObject bulletInst;
                bulletInst = Instantiate(bullet,barrelEnd.position,barrelEnd.rotation);
            }
            yield return new WaitForSeconds(fireRate);
        }
    }
}
