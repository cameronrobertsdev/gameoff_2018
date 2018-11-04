using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {

    bool aware;

    NavMeshAgent nav;

    Transform playerTrans;

    PlayerVitals playerVitals;

    public float health;

    bool died;

    [SerializeField]
    float damage;

    [SerializeField]
    GameObject[] gibs;

    [SerializeField]
    ParticleSystem splosion;

	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();
        playerTrans = GameObject.Find("Player_01").transform;
        playerVitals = playerTrans.gameObject.GetComponent<PlayerVitals>();
        StartCoroutine(Damage());
	}
	
	// Update is called once per frame
	void Update () {

        print(Vector3.Distance(transform.position, playerTrans.position));

        if (aware && !died)
        {
            nav.SetDestination(playerTrans.position);
        }

        if (health <= 0 && !died)
        {
            Die();
        }
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.gameObject.tag == "Player1")
        {
            playerTrans = collision.transform;
            aware = true;
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.transform.gameObject.tag == "Player1")
    //    {
    //        aware = false;
    //    }
    //}

    IEnumerator Damage()
    {
        while (true)
        {

            if (aware && Vector3.Distance(transform.position, playerTrans.position) < 1.5f && health > 0)
            {
                playerVitals.health -= damage;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Die()
    {
        for (int i = 0; i < gibs.Length; i++)
        {
            died = true;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            nav.enabled = false;
            gibs[i].SetActive(true);
            gibs[i].transform.SetParent(null);
            splosion.Play();
            Destroy(gameObject, splosion.main.duration);
        }
    }

}
