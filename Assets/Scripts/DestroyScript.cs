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
<<<<<<< HEAD
			count.planeCount--;
			Destroy (other.gameObject);
=======
			Destroy (other.gameObject); // Destory any object collided with 
>>>>>>> origin/master
		}
	}
}
