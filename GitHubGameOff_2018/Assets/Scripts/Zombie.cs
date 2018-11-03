using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {

    bool aware;

    NavMeshAgent nav;

    Transform playerTrans;

    PlayerVitals playerVitals;

	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        playerVitals = playerTrans.gameObject.GetComponent<PlayerVitals>();
	}
	
	// Update is called once per frame
	void Update () {

        if (aware)
        {
            nav.SetDestination(playerTrans.position);
        }
		
	}

    IEnumerator Damage()
    {
        while (true)
        {

            if (aware && Vector3.Distance(transform.position, playerTrans.position) < 1)
            {
                playerVitals.health -= 1;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

}
