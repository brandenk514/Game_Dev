using UnityEngine;
using System.Collections;

public class SpawnEnvironment : MonoBehaviour {

	public GameObject plane;
	public int planeCount;

	private float zPos;
	private Vector3 originPos;

	// Use this for initialization
	void Start () {
		plane = GameObject.FindGameObjectWithTag ("Ground");
		originPos = plane.transform.position;
		zPos = plane.transform.position.z;
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
			Invoke ("Spawn", 0f);
		}
	}
}
