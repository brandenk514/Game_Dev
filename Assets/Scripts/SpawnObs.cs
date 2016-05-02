using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnObs : MonoBehaviour {

	//public GameObject[] spawnPoints;
	private List<GameObject> obstacles;

	// Use this for initialization
	void Start () {
		//spawnPoints = GameObject.FindGameObjectsWithTag ("spawnPoint");
		obstacles = new List<GameObject>();
		// fill obstacles array
		for (int i = 0; i < transform.childCount; i++) {
			if (transform.GetChild (i).tag.Equals ("Obstacle")) {
				obstacles.Add (transform.GetChild (i).gameObject);
				// obstacles [nextIndex] = transform.GetChild (i).gameObject;
			//} else if (transform.GetChild (i).tag.Equals ("Pickup")){

			}
		}
		// deal with objects array
		// fill by hand with prefabs and instantiate or activate exisiting objects?
			
		if (Random.value <= 0.5f)
			this.obstacles.ToArray () [Random.Range (0, obstacles.Count)].SetActive (true);
		//if (Random.value <= 0.4f)
		//	SpawnPickups ();
	}

	private void SpawnPickups() {



//		for (int i = 0; i < obstacles.Length; i++) {
//			int coinFlip = Random.Range (0, 20);
//			if (coinFlip >= 17) {
//				coinFlip = Random.Range (0, 2);
//				if (coinFlip > 1) {
//					Instantiate (obstacles [i+1], transform.position, Quaternion.identity);
//				} else {
//					Instantiate (obstacles [i], transform.position, Quaternion.identity);
//				}
//			}
//		}
	}

//	private void activateObstacles(){
//		Debug.Log (this.obstacles.Count);
//		this.obstacles.ToArray () [Random.Range (0, obstacles.Count)].SetActive (true);
//	}
}

		/*Instantiate (obstacles [Random.Range (0, obstacles.Length)], transform.position, Quaternion.identity);
		Invoke ("Spawn", Random.Range (spawnMin, spawnMax));*/
