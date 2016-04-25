using UnityEngine;
using System.Collections;

public class SpawnEnvironment : MonoBehaviour {

	public GameObject startPlane;
	public GameObject plane;
	public int planeCount;
	public GameObject plane1;
	public GameObject plane2;
	public GameObject plane3;
	public GameObject plane4;
	private GameObject[] planeOptions;

	//private float zPos;
	private Vector3 originPos;

	// Use this for initialization
	void Start () {
		planeOptions = new GameObject[]{plane, plane1, plane2, plane3, plane4};
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
	}

	public void Spawn() {
		if (planeCount < 10) {
			//plane = GameObject.FindGameObjectWithTag ("Ground");
			originPos += new Vector3 (0, 0, 20f);
			//Instantiate (planeOptions[Random.Range(0,2)], originPos, Quaternion.identity);
			Instantiate (planeOptions[0], originPos, Quaternion.identity);
		}
	}
}
