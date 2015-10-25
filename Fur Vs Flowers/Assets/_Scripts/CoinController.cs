using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	public GameObject sparkle;
	public GameObject coin;
	public GameObject sparkleClone;
	public SpriteRenderer coinAgain;

	public AudioSource coinCollect;

	// Use this for initialization
	void Start () {
		coinCollect = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DestroyCoin()
	{
		Destroy (coin);
	}

	void OnTriggerEnter2D(Collider2D otherGameObject) {
		if (otherGameObject.tag == "Player") {
			Destroy (coinAgain);
			coinCollect.Play();
			//this._Reset();
			sparkleClone = (GameObject) Instantiate(sparkle, coin.transform.position, Quaternion.identity);
			//Invoke("DestroyCloud",1);
			Destroy (sparkleClone,0.5f);
			Invoke("DestroyCoin", 0.5f);
		}
	}
}
