using UnityEngine;
using System.Collections;

public class GroundPController : MonoBehaviour {
	

	public int maxPlatforms;
	public GameObject platform;
	public GameObject enemy;
	public GameObject coin;
	public float horizontalMin = 7.5f;
	public float horizontalMax = 14f;
	public float verticalMin = -6f;
	public float verticalMax = 6;

	//Vector3 enemyPos = originPosition + new Vector3 (Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax), 0);
	
	private Vector2 originPosition;
	
	
	void Start () {
		
		originPosition = transform.position;
		Spawn ();
		
	}
	
	void Spawn()
	{
		for (int i = 0; i < maxPlatforms; i++)
		{	
			Vector2 randomPosition = originPosition + new Vector2 (Random.Range(horizontalMin, horizontalMax), Random.Range (verticalMin, verticalMax));
			Instantiate(platform, randomPosition, Quaternion.identity);
			originPosition = randomPosition;
			Vector2 randomEnemyPosition = originPosition + new Vector2 (Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
			Instantiate(enemy, randomEnemyPosition, Quaternion.identity);
			Vector2 randomCoinPosition = originPosition + new Vector2 (Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
			Instantiate (coin, randomCoinPosition, Quaternion.identity);
		}
	}
	
}

