using UnityEngine;
using System.Collections;

public class SpawnEnvironment : MonoBehaviour {

	private int planeCount;
	public GameObject startPlane;
	public GameObject plane;
	public GameObject plane1;
	private GameObject[] planeOptions;

	public int difficultyMultiplyer;
	private GUIScript gui;

	private int planesSinceLastObstacle;
	public GameObject obstacle1;
	public GameObject obstacle2;
	public GameObject obstacle3;
	public GameObject obstacle4;
	public GameObject obstacle5;
	public GameObject obstacle6;
	private GameObject[] obstacles;

	public GameObject food;
	public GameObject powerup;

	//private float zPos;
	private Vector3 originPos;

	// Use this for initialization
	void Start () {
		planesSinceLastObstacle = 0;
		difficultyMultiplyer = 1;
		gui = FindObjectOfType<GUIScript> ();
		planeOptions = new GameObject[]{plane, plane1};
		obstacles = new GameObject[]{obstacle1, obstacle2, obstacle3, obstacle4, obstacle5, obstacle6};
		//plane = planeOptions [0];
		originPos = startPlane.transform.position;
		//zPos = originPos.z;
		for (int i = 0; i < 10; i++) {
			Spawn ();
		}
	}

	void FixedUpdate(){
		//		plane = GameObject.FindGameObjectWithTag ("Ground");
		//		Spawn ();
		planeCount = GameObject.FindGameObjectsWithTag("Ground").Length;
		Spawn ();

		if (gui.score > 4000) {
			difficultyMultiplyer = 5;
		} else if (gui.score > 3000) {
			difficultyMultiplyer = 4;
		} else if (gui.score > 2000) {
			difficultyMultiplyer = 3;
		} else if (gui.score > 1000) {
			difficultyMultiplyer = 2;
		} else {
			difficultyMultiplyer = 1;
		}
	}

	public void Spawn() {
		if (planeCount < 10) {
			//plane = GameObject.FindGameObjectWithTag ("Ground");
			originPos += new Vector3 (0, 0, 20f);
			Instantiate (planeOptions [Random.Range (0, 2)], originPos, Quaternion.identity);

			// spawn obstacle based on difficulty
			if (Random.value < (0.3f + (0.1f * difficultyMultiplyer)) && planesSinceLastObstacle > 5-difficultyMultiplyer) {
				SpawnObstacle ();
			} else {
				planesSinceLastObstacle++;
			}
				
			// spawn pickup based on difficulty
			if (Random.value > (0.3f + (0.1f * difficultyMultiplyer))) {
				if (Random.value < 0.8f) {
					SpawnPickup (true);
				} else {
					SpawnPickup (false);
				}
			}
		}
	}

	public void SpawnObstacle(){
		float obstacleX = Random.Range (-1f, 1f);
		/* puts a random obstacle in one of three locations on the plane
		 */

		GameObject spawnObstacle = obstacles [Random.Range(0, obstacles.Length)];

		if (spawnObstacle.layer.Equals(4)) {
			Instantiate (spawnObstacle, (originPos + new Vector3 (obstacleX - 5, 0, 0)),
				Quaternion.identity);
		} else {
			Instantiate (spawnObstacle, originPos + new Vector3 (obstacleX, 0, 0), 
				Quaternion.identity);
		}
		planesSinceLastObstacle = 0;
	}

	// takes true (food) or false (random powerup)
	void SpawnPickup(bool type){
		GameObject pickup;
		if (type) {
			pickup = food;
		} else {
			pickup = powerup;
		}
		Instantiate (pickup, originPos + new Vector3 (Random.Range (-4f, 4f), 1f , Random.Range (-2f, 2f)), Quaternion.identity);

	}
}
