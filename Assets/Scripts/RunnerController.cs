using UnityEngine;
using System.Collections;

public class RunnerController : MonoBehaviour {

	[HideInInspector] public bool jump = false;
	public float moveForce;
	public float speed;
	public float jumpForce;

	private float lastJump;
	private Rigidbody rb;
	private Transform t;
	private Animator anim;


	// Use this for initialization
	void Start () {
		t = GetComponent<Transform> ();
		anim = GetComponent<Animator> ();
		t.transform.Rotate (0, 90, 0);
	}

	// Update is called once per frame
	void Update () {
		float v = 2f;
		anim.SetFloat ("Forward", v);
		if (Input.GetKey(KeyCode.Space)) {
			jump = true;
			Debug.Log ("jump");
		}
	}

	/*void FixedUpdate() {
		float h = Input.GetAxis ("Horizontal");
		if (moveForce * rb.velocity.z < speed) {
			rb.AddForce (Vector3.forward * moveForce);
		}
		if (jump) {
			rb.AddForce(new Vector3(0f, jumpForce, 0f));
			if (Time.time - lastJump > 3f) {
				rb.AddForce(new Vector3(0f, jumpForce, 0f));
				jump = false;
				Debug.Log (lastJump);
				lastJump = Time.time;
			}
		}
		if (h * rb.velocity.x < speed) {
			rb.AddForce (Vector3.right * h * moveForce);
		} else if (h * rb.velocity.x > speed) {
			rb.AddForce (Vector3.left * h * moveForce);
		}
	}*/
}
