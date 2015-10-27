/// Jonathan Lee 822937603
/// File: CoinController.cs
/// Last Updated: October 26th, 2015
/// Controls the Coin, instantiation of the sparkle and collection sound

using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {


	// PUBLIC INSTANCE VARIABLES
	public GameObject sparkle;
	public GameObject coin;
	public GameObject sparkleClone;
	public SpriteRenderer coinAgain;

	public AudioSource coinCollect;

	// Use this for initialization
	void Start () {
		//Gets the coin collection audio source into variable 
		coinCollect = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Method to fully destroy the coin
	void DestroyCoin()
	{
		//Destroys coin game object
		Destroy (coin);
	}

	//Method to trigger colliders, coin hits Player
	void OnTriggerEnter2D(Collider2D otherGameObject) {
		//Detect if colliders are hitting player
		if (otherGameObject.tag == "Player") {
			//Destroy the sprite so image disappears 
			Destroy (coinAgain);
			//Play the sound of coin collection
			coinCollect.Play();
			//Instantiate the sparkle after collection sprite, at the location of the coin
			sparkleClone = (GameObject) Instantiate(sparkle, coin.transform.position, Quaternion.identity);
			//Destroy the sparkle sprite after the time required to go though its animation loop
			Destroy (sparkleClone,0.5f);
			//Destroy the entire coin game object to clean up
			Invoke("DestroyCoin", 0.5f);
		}
	}
}
