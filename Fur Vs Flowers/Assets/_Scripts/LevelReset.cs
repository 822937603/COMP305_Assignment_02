using UnityEngine;
using System.Collections;

public class LevelReset : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

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
