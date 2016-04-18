using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

	private SpawnEnvironment count;

	void Start(){
		count = FindObjectOfType<SpawnEnvironment> ();
	}

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			Debug.Break ();
			return;
		} else {
			count.planeCount--;
			Destroy (other.gameObject);
		}
	}
}
