using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject smoke;
	public GameObject enemy;
	private GameObject smokeClone;

	public SpriteRenderer enemyAgain;
	
	public AudioSource enemySound;
	// Use this for initialization
	void Start () {
		enemySound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DestroyEnemy()
	{
		Destroy (enemy);
	}

	//Collision Code for sound and reset
	void OnTriggerEnter2D(Collider2D otherGameObject) {
		if (otherGameObject.tag == "Player") {
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
