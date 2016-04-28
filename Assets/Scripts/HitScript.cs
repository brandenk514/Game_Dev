using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

	public comp_cs player; 
	float hitTimer; 

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<comp_cs> ();
	}
		
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			if (player.tripped) {
				player.dead = true;
			} else {
				player.tripped = true;
			}
		}

	}
}
