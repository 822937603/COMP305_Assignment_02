using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FurryCollider : MonoBehaviour {

	public Text scoreLabel;
	public Text livesLabel;
	public Text gameOverLabel;
	public Text finalScoreLabel;
	public int  scoreValue = 0;
	public int  livesValue = 5;

	public SpriteRenderer FurryAgain;
	public Rigidbody2D rd2d;

	// Use this for initialization
	void Start () {
		rd2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherGameObject) {
		
		if (otherGameObject.tag == "Enemy") {
			//this._cloudAudioSource.Play ();
			this.livesValue--; // remove one life
			this.scoreValue -= 1000; //decrease score
			if (this.livesValue == 0) {
				//Destroy (gameObject);
				Destroy(FurryAgain);
				Destroy(rd2d);
			}
			if(this.livesValue <= 0) {
				this._EndGame();
			}
		}
		if (otherGameObject.tag == "Item") {
			this.scoreValue += 1000;
		}
		
		this._SetScore ();
	}
	
	//scoring set
	private void _SetScore() {
		this.scoreLabel.text = "Score: " + this.scoreValue;
		this.livesLabel.text = "Lives: " + this.livesValue;
	}
	
	//For the Game Over
	private void _EndGame() {
		//Destroy(gameObject);
		Destroy (FurryAgain);
		Destroy (rd2d);
		this.scoreLabel.enabled = false;
		this.livesLabel.enabled = false;
		this.gameOverLabel.enabled = true;
		this.finalScoreLabel.enabled = true;
		this.finalScoreLabel.text = "Final Score: " + this.scoreValue;
		this.gameOverLabel.text = "GAME OVER";
	}
}
