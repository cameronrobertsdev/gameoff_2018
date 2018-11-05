using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Ammo : MonoBehaviour {

    [SerializeField]
    AudioClip clip;

    [SerializeField]
    AudioSource audioSource;

    GameObject affectedObject;

    Camera cam;


    private void Start()
    {
        cam = Camera.main;
        audioSource = GameObject.Find("Ammo Sound").GetComponent<AudioSource>();
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

        for (int i = 0; i < cam.transform.childCount - 1; i++)
        {
            cam.transform.GetChild(i).GetComponent<Gun>().totalAmmo += 10;
        }

        Destroy(gameObject);
    }

    


}
