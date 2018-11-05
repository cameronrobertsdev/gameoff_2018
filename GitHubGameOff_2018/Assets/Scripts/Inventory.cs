using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


    int currentItem;   
	// Use this for initialization
	void Start () {
        PickWeapon();
        print(transform.GetChild(0));
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
            int quickKey = int.Parse(Input.inputString);
            if (quickKey > 0 && quickKey <= transform.childCount)
            {
                currentItem = quickKey - 1;
                PickWeapon();
            }
        }

        //print(Input.GetAxisRaw("Mouse ScrollWheel"));

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            if (currentItem >= transform.childCount - 1)
            {
                currentItem = 0;
                PickWeapon();
            }
            else
            {
                currentItem++;
                PickWeapon();
            }
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            if (currentItem <= 0)
            {
                currentItem = transform.childCount - 1;
                PickWeapon();
            }
            else
            {
                currentItem--;
                PickWeapon();
            }
        }

    }


    void PickWeapon()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i != currentItem)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            if (i == currentItem)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        //print("current item: " + currentItem);
    }
}