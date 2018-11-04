using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is simply a template from whic to be build all the unique pickups in the game
//It should not be used on any real object in the game.
//In a perfect world this script would be used for every pickup in the game with slight modifications made to it for each object.
//Unfortunately I don't have the time to do that sort of thing riht now.


public class Coins : MonoBehaviour {

    [SerializeField]
    ParticleSystem particles;

    [SerializeField]
    AudioClip clip;

    AudioSource audioSource;

    GameObject affectedObject;

    private void Start()
    {
        audioSource = GameObject.Find("Coin Sound").GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player1")
        {
            affectedObject = other.gameObject;
            Collect();
        }
        
    }

    void Collect()
    {
        //Get the script with values to be modified here.
        //Then add to it
        GetComponent<Collider>().enabled = false;
        audioSource.clip = clip;
        affectedObject.GetComponent<PlayerVitals>().coins += 1;
        audioSource.Play();

        particles.Play();
        GetComponent<Renderer>().enabled = false;
        Destroy(gameObject, particles.main.duration);
    }

    


}
