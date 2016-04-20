using UnityEngine;
using System.Collections;

public class SpawnObs : MonoBehaviour {

	//public GameObject[] spawnPoints;
	public GameObject[] obstacles;

	// Use this for initialization
	void Start () {
		//spawnPoints = GameObject.FindGameObjectsWithTag ("spawnPoint");
		Spawn ();
	}

	void Spawn() {
		for (int i = 0; i < obstacles.Length; i++) {
			int coinFlip = Random.Range (0, 20);
			if (coinFlip >= 17) {
				coinFlip = Random.Range (0, 2);
				if (coinFlip > 1) {
					Instantiate (obstacles [i+1], transform.position, Quaternion.identity);
				} else {
					Instantiate (obstacles [i], transform.position, Quaternion.identity);
				}
			}
		}
	}
}

		/*Instantiate (obstacles [Random.Range (0, obstacles.Length)], transform.position, Quaternion.identity);
		Invoke ("Spawn", Random.Range (spawnMin, spawnMax));*/
