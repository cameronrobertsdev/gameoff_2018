using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AddToInventory : MonoBehaviour {


    [SerializeField]
    AudioClip clip;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    GameObject objectToAdd;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1")
        {
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

        Instantiate(objectToAdd);

        objectToAdd.transform.parent = cam.transform;

        objectToAdd.transform.position = cam.transform.GetChild(0).transform.position;
        objectToAdd.transform.rotation = cam.transform.GetChild(0).transform.rotation;

        Destroy(gameObject);


    }

    


}
