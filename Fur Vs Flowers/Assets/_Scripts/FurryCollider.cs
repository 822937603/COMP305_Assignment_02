/// Jonathan Lee 822937603
/// File: FurryCollider.cs
/// Last Updated: October 26th, 2015
/// Controls the collisions for the Player as well as handles the scoring/life

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FurryCollider : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public Text scoreLabel;
	public Text livesLabel;
	public Text gameOverLabel;
	public Text finalScoreLabel;
	//Score starts at zero
	public int  scoreValue = 0;
	//Lives start at five
	public int  livesValue = 5;

	public SpriteRenderer FurryAgain;
	public Rigidbody2D rd2d;

	// Use this for initialization
	void Start () {
		//Gets the RigidBody for the player into variable
		rd2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Method to handle collisions between player and enemies/item
	void OnTriggerEnter2D(Collider2D otherGameObject) {

		//Condition when player collides with enemy
		if (otherGameObject.tag == "Enemy") {
			this.livesValue--; // remove one life
			this.scoreValue -= 100; //decrease score
			//Condition for when life reaches 0
			if (this.livesValue == 0) {
				//Destroy SpriteRenderer so that player is not visible
				Destroy(FurryAgain);
				//Destroy RigidBody to prevent additional movement
				Destroy(rd2d);
			}
			//When lives reach 0 run the end game, game over screen method
			if(this.livesValue <= 0) {
				//Calls the end game, game over screen
				this._EndGame();
			}
		}

		//Collision condition for player colliding with coin item
		if (otherGameObject.tag == "Item") {
			//On collision add 100 to the score
			this.scoreValue += 100;
		}

		//Show the score and lives value to the canvas for player viewing
		this._SetScore ();
	}
	
	//Method to set the scoring in the text canvas
	private void _SetScore() {
		//Sets and displays the score
		this.scoreLabel.text = "Score: " + this.scoreValue;
		//Sets and displays the lives
		this.livesLabel.text = "Lives: " + this.livesValue;
	}


	//Method for the Game Over
	private void _EndGame() {
		//Destroy Player SpriteRenderer to hide from view
		Destroy (FurryAgain);
		//Destroy Player RigidBody to prevent Player from moving
		Destroy (rd2d);
		//Sets score text as false to hide it from view
		this.scoreLabel.enabled = false;
		//Sets lives text as false to hide it from view
		this.livesLabel.enabled = false;
		//Sets Game Over text as true to display on canvas
		this.gameOverLabel.enabled = true;
		//Sets Final Score text as true to display on canvas
		this.finalScoreLabel.enabled = true;
		//Sets the text within the final score box, displays to player
		this.finalScoreLabel.text = "Final Score: " + this.scoreValue;
		//Sets the text within the Game Over box, displays to player
		this.gameOverLabel.text = "GAME OVER";
	}
}
