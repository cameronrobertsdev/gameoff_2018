using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is simply a template from whic to be build all the unique pickups in the game
//It should not be used on any real object in the game.
//In a perfect world this script would be used for every pickup in the game with slight modifications made to it for each object.
//Unfortunately I don't have the time to do that sort of thing riht now.


public class Pickup : MonoBehaviour {

    [SerializeField]
    ParticleSystem particles;

    [SerializeField]
    AudioClip clip;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    GameObject affectedObject;


    private void OnTriggerEnter(Collider other)
    {
        
    }

    void Collect()
    {
        //Get the script with values to be modified here.
        //Then add to it

        audioSource.clip = clip;

        audioSource.Play();

        particles.Play();
        GetComponent<Renderer>().enabled = false;
    }

    


}
