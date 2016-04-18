using UnityEngine;
using System.Collections;

public class RunnerController : MonoBehaviour {

	[HideInInspector] public bool jump = false;
	public float moveForce;
	public float speed;
	public float jumpForce;
	public Transform groundCheck;
	public bool grounded;
	private float lastJump;

	private Rigidbody rb; 


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));
		grounded = true;
		if ((Input.GetButtonDown("Jump")) && grounded) {
			jump = true;

		}
	}

	void FixedUpdate() {
		float h = Input.GetAxis ("Horizontal");
		if (moveForce * rb.velocity.z < speed) {
			rb.AddForce (Vector3.forward * moveForce);
		}
		if (jump) {
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
	}
}
