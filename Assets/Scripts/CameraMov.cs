using UnityEngine;
using System.Collections;

public class CameraMov : MonoBehaviour {

	public float smooth = 1.5f;

	private Transform player;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;

	}

	void FixedUpdate() {
		transform.position = Vector3.Lerp (transform.position, player.transform.position + new Vector3(0, 7f, -0.5f), smooth * Time.deltaTime);
	}
}
