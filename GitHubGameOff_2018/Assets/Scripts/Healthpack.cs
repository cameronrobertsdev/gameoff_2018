using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Healthpack : MonoBehaviour {

    [SerializeField]
    float ammount;

    [SerializeField]
    AudioClip clip;

    [SerializeField]
    AudioSource audioSource;

    GameObject affectedObject;

    private void Start()
    {
        audioSource = GameObject.Find("Health Sound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
            affectedObject = other.gameObject;
            Collect();
        }
    }

    void Collect()
    {
        //Get the script with values to be modified here.
        //Then add to it

        audioSource.clip = clip;

        audioSource.Play();

        GetComponent<Renderer>().enabled = false;

        affectedObject.GetComponent<PlayerVitals>().health += ammount;

        Destroy(gameObject);
    }

    


}
