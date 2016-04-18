using UnityEngine;
using System.Collections;

public class SpawnEnvironment : MonoBehaviour {

	public GameObject plane;
<<<<<<< HEAD
	public float zPos;
	public int planeCount;
=======
>>>>>>> origin/master

	private float zPos,counter;
	private Vector3 originPos;
	private GameObject player;

	// Use this for initialization
	void Start () {
		plane = GameObject.FindGameObjectWithTag ("Ground");
		player = GameObject.FindGameObjectWithTag ("Player");
		originPos = plane.transform.position;
		zPos = plane.transform.position.z;
		Spawn ();
	}

<<<<<<< HEAD
	void FixedUpdate(){
		Spawn ();
	}

	private void Spawn() {
		if (planeCount < 15) {
			Vector3 nextPos = originPos + new Vector3 (0, 0, 8*zPos++);
			planeCount++;
			Instantiate (plane, nextPos, Quaternion.identity);
		}
		//Invoke ("Spawn", 0f);
=======
	void Spawn() {
		Vector3 nextPos = originPos + new Vector3 (0, plane.transform.position.y, 20f * zPos++);
		Instantiate (plane, nextPos, Quaternion.identity);
		Invoke ("Spawn", 0f);
>>>>>>> origin/master
	}
}
