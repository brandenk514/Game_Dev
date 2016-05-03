using UnityEngine;
using System.Collections;

public class SpawnEnvironment : MonoBehaviour {

	private int planeCount;
	public GameObject startPlane;
	public GameObject plane;
	public GameObject plane1;
	private GameObject[] planeOptions;

	private int planesSinceLastObstacle;
	public GameObject obstacle1;
	public GameObject obstacle2;
	public GameObject obstacle3;
	private GameObject[] obstacles;

	public GameObject food;
	public GameObject powerup;

	//private float zPos;
	private Vector3 originPos;

	// Use this for initialization
	void Start () {
		planesSinceLastObstacle = 0;
		planeOptions = new GameObject[]{plane, plane1};
		obstacles = new GameObject[]{obstacle1,obstacle2, obstacle3};
		//plane = planeOptions [0];
		originPos = startPlane.transform.position;
		//zPos = originPos.z;
		for (int i = 0; i < 20; i++) {
			Spawn ();
		}
	}

	void FixedUpdate(){
		//		plane = GameObject.FindGameObjectWithTag ("Ground");
		//		Spawn ();
		planeCount = GameObject.FindGameObjectsWithTag("Ground").Length;
	}

	public void Spawn() {
		if (planeCount < 10) {
			//plane = GameObject.FindGameObjectWithTag ("Ground");
			originPos += new Vector3 (0, 0, 20f);
			Instantiate (planeOptions [Random.Range (0, 2)], originPos, Quaternion.identity);

			// obstacles must be at least 1 plane apart
			// spawn in 7 out of every 10 valid planes
			if (Random.value < 0.7f && planesSinceLastObstacle > 1) {
				SpawnObstacle ();
			} else {
				planesSinceLastObstacle++;
			}

			// 20% chance a pickup appears
			// 50% chance of being food or a powerup
			if (Random.value < 0.2f) {
				if (Random.value < 0.5f) {
					SpawnPickup (true);
				} else {
					SpawnPickup (false);
				}
			}
		}
	}

	public void SpawnObstacle(){
		float obstacleX = Random.Range (-0.5f, 0.5f);
		/* puts a random obstacle in one of three locations on the plane
		 */
		Instantiate (obstacles [Random.Range (0, obstacles.Length)], originPos + new Vector3 (obstacleX, 0, 0), 
			Quaternion.identity);
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
		Instantiate (pickup, originPos + new Vector3 (Random.Range (1f, 1f), 1f , Random.Range (1f, 1f)), Quaternion.identity);

	}
}
