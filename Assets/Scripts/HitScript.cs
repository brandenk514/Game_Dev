using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

	public comp_cs player; 

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<comp_cs> ();
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			if (player.tripped) {
			//if (true){
				player.dead = true;
			} else {
				player.tripped = true;
			}
		}
	}
}
