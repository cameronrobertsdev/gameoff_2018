using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitals : MonoBehaviour {

    public float health = 100;

    public bool alive = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!alive)
        {
            Die();
        }
		
	}

    void Die()
    {
        //write stuff in here to activate things like death screens, stop player movement and shooting etc.

    }
}
