using UnityEngine;
using System.Collections;

public class SpawnEnvironment : MonoBehaviour {

	public GameObject plane;
	public float zPos;

	private Vector3 originPos;
	private GameObject player;

	// Use this for initialization
	void Start () {
		originPos = plane.transform.position;
		zPos = plane.transform.position.z;
		player = GameObject.FindGameObjectWithTag ("Player");
		Spawn ();
	}

	private void Spawn() {
		Vector3 nextPos = originPos + new Vector3 (0, plane.transform.position.y, 10 * zPos++);
		Instantiate (plane, nextPos, Quaternion.identity);
		Invoke ("Spawn", 0f);
	}
}
