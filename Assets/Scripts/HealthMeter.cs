using UnityEngine;
using System.Collections;

public class HealthMeter : MonoBehaviour {
	public float health;
	public float xPos;
	public float size;
	public float xChange;
	public int z=0;
	public GameObject comp;
	public float currentHealth;

	// Use this for initialization
	void Start () {
		xPos = gameObject.transform.position.x;
		currentHealth = comp.GetComponent<comp_cs> ().health;
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth = comp.GetComponent<comp_cs> ().health;
		xChange = currentHealth - health;
		health = currentHealth;
		xChange = xChange / 100f;
		xChange = xChange * size;
		Vector3 temp = new Vector3 (xChange, 0, 0);
		gameObject.transform.position += temp;
		//Wait5 ();
	}

	IEnumerator Wait5() {
		yield return new WaitForSeconds (3);
	}
}
