using UnityEngine;
using System.Collections;

public class SpawnEnvironment : MonoBehaviour {

	public GameObject plane;
	public float zPos;
	public int planeCount;

	private Vector3 originPos;
	private GameObject player;

	// Use this for initialization
	void Start () {
		originPos = plane.transform.position;
		zPos = plane.transform.position.z;
		player = GameObject.FindGameObjectWithTag ("Player");
		Spawn ();
	}

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
	}
}
