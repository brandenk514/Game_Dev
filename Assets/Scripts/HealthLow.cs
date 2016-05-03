using UnityEngine;
using System.Collections;

public class HealthLow : MonoBehaviour {
	public GameObject comp;
	public float health;
	//private Canvas  Gui;

	// Use this for initialization
	void Start () {
		health = comp.GetComponent<comp_cs> ().health;
		//Gui = FindObjectOfType<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		health = comp.GetComponent<comp_cs> ().health;
		if (health < 25) {
			gameObject.GetComponent<MonoBehaviour> ().enabled = true;
		}
	}
}
