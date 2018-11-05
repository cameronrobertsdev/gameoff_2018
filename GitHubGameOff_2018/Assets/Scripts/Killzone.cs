using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour {

    bool active;

    [SerializeField]
    float damage;

    PlayerVitals playerVitals;

    private void Start()
    {
        playerVitals = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerVitals>();

        StartCoroutine(Hurt());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            active = false;
        }
    }

    IEnumerator Hurt()
    {
        while (true)
        {
            if (active)
            {
                playerVitals.health -= damage;
            }

            yield return new WaitForSeconds(1);
        }
    }

}
