using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			Debug.Break ();
			return;
		} else {
			Destroy (other.gameObject); // Destory any object collided with 
		}
	}
}
