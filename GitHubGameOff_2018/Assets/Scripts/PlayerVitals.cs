using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerVitals : MonoBehaviour {

    public float health = 100;

    public bool alive = true;

    Move playerMove;
    Gun[] allguns;

    Camera cam;

    [SerializeField]
    RawImage redOverlay;

    [SerializeField]
    Text healthText;

    //This text should show how many coins the player has collected.
    [SerializeField]
    Text coinsText;

    //These items are ui elements that activate when you when the game
    [SerializeField]
    RawImage greenOverlay;

    [SerializeField]
    Text winText;


    public int coins;

    int totalCoins;

	// Use this for initialization
	void Start () {
        playerMove = GetComponent<Move>();
        allguns = GetComponentsInChildren<Gun>();
        cam = GetComponentInChildren<Camera>();
        winText.enabled = false;
        greenOverlay.enabled = false;
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        redOverlay.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        healthText.text = "Health: " + health.ToString();

        coinsText.text = "Coins: " + coins.ToString();

        if (health == 0)
        {
            alive = false;
        }

        if (!alive)
        {
            Die();

            if (Input.GetAxisRaw("Fire1") == 1)
            {
                StartCoroutine(LoadYourAsyncScene());
            }
        }

        //Put the necessary requirements for completing the game in this if statement
        if (alive && coins == totalCoins)
        {
            Win();
        }
		
	}

    void Die()
    {
        //write stuff in here to activate things like death screens, stop player movement and shooting etc.
        for (int i = 0; i < allguns.Length; i++)
        
        {
            allguns[i].enabled = false;
        }

        cam.gameObject.transform.localPosition = new Vector3(0, -0.8f, 0);

        playerMove.enabled = false;

        redOverlay.enabled = true;
    }

    void Win()
    {
        winText.enabled = true;
        greenOverlay.enabled = true;
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
