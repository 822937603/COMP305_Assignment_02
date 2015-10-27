/// Jonathan Lee 822937603
/// File: EnemyController.cs
/// Last Updated: October 26th, 2015
/// Controls the collisions for the Enemy and the death puff of smoke

using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public GameObject smoke;
	public GameObject enemy;
	private GameObject smokeClone;

	public SpriteRenderer enemyAgain;
	
	public AudioSource enemySound;

	// Use this for initialization
	void Start () {

		//Gets the fly death buzz sound into variable
		enemySound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Method to fully destroy the Enemy
	void DestroyEnemy()
	{
		//Destroys Enemy fully
		Destroy (enemy);
	}

	//Collision Code for sound and reset
	void OnTriggerEnter2D(Collider2D otherGameObject) {
		//Collision detection for colliding with the Player
		if (otherGameObject.tag == "Player") {
			//Play the fly buzz 
			enemySound.Play();
			//this._Reset();
			//Destroy (gameObject);
			smokeClone = (GameObject) Instantiate(smoke, enemy.transform.position, Quaternion.identity);
			//Invoke("DestroyCloud",1);
			Destroy (smokeClone,0.5f);
			Invoke ("DestroyEnemy", 0.5f);

		}
	}

	//void DestroyCloud () {
	//	Destroy (smoke);
	//}
}
