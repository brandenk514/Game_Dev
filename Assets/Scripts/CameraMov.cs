using UnityEngine;
using System.Collections;

public class CameraMov : MonoBehaviour {

	public float smooth = 1.5f;
	public comp_cs playerTime;
	public GameObject destroyer1;
	private Transform player;

	public bool Shaking;
	private float ShakeDecay;
	private float ShakeIntensity;
	private Vector3 OriginalPos;
	private Quaternion OriginalRotation;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerTime = FindObjectOfType<comp_cs> ();
		Shaking = false;
	
		transform.position = new Vector3 (-5f, 10f, 10f); //Initial Pos
		transform.rotation = Quaternion.Euler (50f, 120f, 0f); // Initial Rotation
		StartCoroutine (activateDestroyers());

	}

	void Update() {
		if (ShakeIntensity > 0) {
			transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
			transform.rotation = new Quaternion (OriginalRotation.x + Random.Range (-ShakeIntensity, ShakeIntensity) * .2f, 
				OriginalRotation.y + Random.Range (-ShakeIntensity, ShakeIntensity) * .2f,
				OriginalRotation.z + Random.Range (-ShakeIntensity, ShakeIntensity) * .2f,
				OriginalRotation.w + Random.Range (-ShakeIntensity, ShakeIntensity) * .2f);
			ShakeIntensity -= ShakeDecay;
		} else if (Shaking) {
			Shaking = false;
		} else {

		}
	}

	void FixedUpdate() {
		Vector3 abovePos = player.position + new Vector3 (0, 5f, -0.5f);

		if (Time.time - playerTime.startTimer > 3f) {
			transform.position = Vector3.Lerp (transform.position, abovePos, smooth * Time.deltaTime); // follows player
			smoothLookAt ();
		}

	}

	void smoothLookAt() {
		Quaternion lookAtRot = Quaternion.Euler (30, 0, 0); // X angle is at 30 to see player
		transform.rotation = Quaternion.Lerp (transform.rotation, lookAtRot, smooth * Time.deltaTime); //Looks at the player
	}

	IEnumerator activateDestroyers(){
		yield return new WaitForSeconds (5f);
		// activate destroyers
		destroyer1.SetActive(true);
		yield return null;
	}

	public void shake() {
		OriginalPos = transform.position;
		OriginalRotation = transform.rotation;
		ShakeIntensity = 0.2f;
		ShakeDecay = 0.02f;
		Shaking = true;
	}
}
