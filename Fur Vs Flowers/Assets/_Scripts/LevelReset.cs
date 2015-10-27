using UnityEngine;
using System.Collections;

public class LevelReset : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//The R key reset
		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	//For Testing purposes, tried to make a collider reset didnt work
	void OnTriggerEnter2D(Collider2D other)
	{

		//Application.LoadLevel(Application.loadedLevel);
		//if (Input.GetKeyDown(KeyCode.R)) {
		//	Application.LoadLevel(Application.loadedLevel);
		//}
		//if (other.gameObject.CompareTag ("Player"))
		//{
		//
		//	Application.LoadLevel(Application.loadedLevel);
		//	Application.LoadLevel(0);
		//
		//}
	}
}
