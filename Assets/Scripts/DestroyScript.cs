using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

	private SpawnEnvironment count;

	void Start(){
		count = FindObjectOfType<SpawnEnvironment> ();
	}

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player") || other.CompareTag ("Enemy")) {
			
		} else {
			count.Spawn ();
			Destroy (other.gameObject);
		}
	}
}
