using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {


    float shoot;
    bool triggerDown;
    [SerializeField]
    bool fullAuto;
    [SerializeField]
    int magSize;

    [SerializeField]
    float range;

    [SerializeField]
    float damage;

    [SerializeField]
    float fireRate;

    [SerializeField]
    float kick;

    int currentMag;


    public int totalAmmo;

    [SerializeField]
    int reloadTime;

    int currentReloadTime;

    bool reloading;

    float reloadButton;

    [SerializeField]
    Text currentClipText;
    [SerializeField]
    Text totalAmmoText;
    [SerializeField]
    Text reloadText;

    [SerializeField]
    ParticleSystem hitParticles;

    [SerializeField]
    ParticleSystem muzzleFlash;

    Transform cam;
	// Use this for initialization
	void Start () {
        if (transform.parent.gameObject.tag != "Enemy")
        {
            cam = GetComponentInParent<Camera>().transform;
        }
        else
        {
            cam = transform.parent.transform;
        }
        currentMag = magSize;
        if (fullAuto)
        {
            StartCoroutine(AutoFire());
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag == "Player1")
        {
            shoot = Input.GetAxisRaw("Fire1");
            reloadButton = Input.GetAxisRaw("Reload");
        }
        if (gameObject.tag == "Player2")
        {
            shoot = Input.GetAxisRaw("Fire1P2");
            reloadButton = Input.GetAxisRaw("ReloadP2");
        }
        totalAmmoText.text = totalAmmo.ToString();
        currentClipText.text = currentMag.ToString();


        if (!reloading && !triggerDown && currentMag < magSize && reloadButton == 1)
        {
            StartCoroutine( Reload());
            reloading = true;
        }

        if (shoot == 1 && !triggerDown && currentMag > 0 && !reloading)
        {
            currentMag -= 1;
            RaycastHit hit;
            cam.Rotate(cam.InverseTransformDirection(cam.right) * kick);
            muzzleFlash.Play();
            if (Physics.Raycast(cam.position, cam.forward, out hit, range))
            {
                //print("I hit: " + hit.transform.gameObject.name);
                ParticleSystem hitInst;
                hitInst = Instantiate(hitParticles,hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)) as ParticleSystem;
               // print(hit.normal);
                hitInst.Play();

                if (hit.transform.gameObject.tag == "Zombie")
                {
                    hit.transform.gameObject.GetComponent<Zombie>().health -= damage;
                }

                if (hit.transform.gameObject.GetComponent<Rigidbody>() != null)
                {
                    Rigidbody tempRigid;
                    tempRigid = hit.transform.gameObject.GetComponent<Rigidbody>();
                    tempRigid.AddForceAtPosition(-hit.normal * 1000, hit.point);
                }
            }
            triggerDown = true;
        }
        if (shoot == 0)
        {
            triggerDown = false;
        }
        if (reloading)
        {
            reloadText.enabled = true;
        }
        else
        {
            reloadText.enabled = false;
        }

        if (totalAmmo == 0)
        {
            reloadText.text = "OUT OF AMMO!";
        }
        else
        {
            reloadText.text = "RELOADING...";
        }


		
	}

    IEnumerator AutoFire()
    {
        while (true)
        {
            if (fullAuto)
            {
                if (currentMag > 0 && !reloading && triggerDown)
                {
                    currentMag -= 1;

                    cam.Rotate(cam.InverseTransformDirection(cam.right) * kick);


                    RaycastHit hit;
                    if (Physics.Raycast(cam.position, cam.forward, out hit, range))
                    {

                        if (hit.transform.gameObject.GetComponent<Rigidbody>() != null)
                        {
                            Rigidbody tempRigid;
                            tempRigid = hit.transform.gameObject.GetComponent<Rigidbody>();
                            tempRigid.AddForceAtPosition(-hit.normal * 1000, hit.point);
                        }

                        //print("I hit: " + hit.transform.gameObject.name);
                        ParticleSystem hitInst;
                        hitInst = Instantiate(hitParticles, hit.point, new Quaternion(hit.normal.x, hit.normal.y, hit.normal.z, 0)) as ParticleSystem;
                        hitInst.Play();
                    }

                }
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    IEnumerator Reload()
    {
        //print("Reload was called.");
        yield return new WaitForSeconds(reloadTime);
        totalAmmo -= magSize - currentMag;
        currentMag = magSize;
         if (totalAmmo < 0)
         {
            currentMag = currentMag + totalAmmo;
            totalAmmo = 0;
         }
         reloading = false;
    }

}
