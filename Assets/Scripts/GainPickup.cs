using UnityEngine;
using System.Collections;

public class GainPickup : MonoBehaviour {

	private comp_cs player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<comp_cs> ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			// activate powerup here
			if (this.CompareTag("Food")){
				// player.health += 20 or some shit like that
				player.EatFood();
			} else if (this.CompareTag("Powerup")){
				player.ActivatePowerup (Random.Range (0, 3));
			}

			Destroy (this.gameObject);
		}

	}
}
