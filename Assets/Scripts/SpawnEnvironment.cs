using UnityEngine;
using System.Collections;

public class SpawnEnvironment : MonoBehaviour {

	public GameObject plane;

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

	void Spawn() {
		Vector3 nextPos = originPos + new Vector3 (0, plane.transform.position.y, 20f * zPos++);
		Instantiate (plane, nextPos, Quaternion.identity);
		Invoke ("Spawn", 0f);
	}
}
