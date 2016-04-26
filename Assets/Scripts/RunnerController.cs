using UnityEngine;
using System.Collections;

public class RunnerController : MonoBehaviour {

	public float smooth = 1.5f;

	private Rigidbody rb;
	private Transform t;
	private Animator anim;
	private GameObject player;
	public float startTimer, hitTimer;
	public comp_cs playerTrip;


	// Use this for initialization
	void Start () {
		t = GetComponent<Transform> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTrip = FindObjectOfType<comp_cs> ();
		anim = GetComponent<Animator> ();
		t.transform.Rotate (0, 90, 0); //Set enemy rotation
	}
		
	void FixedUpdate () {
		float v = 2f;
		anim.SetFloat ("Forward", v);
		if (Time.time - startTimer > 4f) {
			transform.position = Vector3.Lerp (transform.position, player.transform.position, smooth * Time.deltaTime); //Lerps after player
			if (playerTrip.tripped) {
				StartCoroutine(Lerpfor3());
			}
		}
			
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("End Screen");
		}
	}

	IEnumerator Lerpfor3() {
		Vector3 halfDist = (player.transform.position - transform.position) / 1.5f; 
		transform.position = Vector3.Lerp (transform.position, (player.transform.position - halfDist), smooth * Time.fixedDeltaTime); //trip, then half distance;
		yield return new WaitForSeconds(5f);
		playerTrip.tripped = false;
		yield return null;
	}
}
