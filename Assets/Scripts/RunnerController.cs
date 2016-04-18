using UnityEngine;
using System.Collections;

public class RunnerController : MonoBehaviour {

	[HideInInspector] public bool jump = false;
	public float smooth = 0.5f;

	private float lastJump;
	private Rigidbody rb;
	private Transform t;
	private Animator anim;
	private GameObject player;
	public float startTimer = 0f, hitTimer;
	public comp_cs playerTripped;

	// Use this for initialization
	void Start () {
		t = GetComponent<Transform> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTripped = FindObjectOfType<comp_cs> ();
		anim = GetComponent<Animator> ();
		t.transform.Rotate (0, 90, 0); //Set enemy rotation
	}
		
	void FixedUpdate () {
		float v = 2f;
		anim.SetFloat ("Forward", v);
		if (Input.GetKey(KeyCode.Space)) {
			jump = true;
		}
		if (Time.time - startTimer > 4f) {
			transform.position = Vector3.Lerp (transform.position, player.transform.position, smooth * Time.deltaTime); //Lerps after player
			if (playerTripped.tripped) {
				StartCoroutine(Lerpfor3());
			}
		}
			
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			Debug.Log ("Dead");
			Debug.Break ();
		}
	}

	IEnumerator Lerpfor3() {
		Vector3 halfDist = (player.transform.position - transform.position) / 2;  
		transform.position = Vector3.Lerp (transform.position, (player.transform.position - halfDist), smooth * Time.deltaTime); //trip, then half distance
		yield return new WaitForSeconds(5);
		playerTripped.tripped = false;
	}
}
