using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public float score;
	public MonoBehaviour Text;
	// Use this for initialization
	void Start () {
		score = 0;
		//Text = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		score = score + Time.deltaTime;
		Debug.Log (gameObject.GetComponent<GUIText> ().text);
		//= "Score: " + score.ToString();
		//gameObject.GetComponent<MonoBehaviour>() = "Score: " + score.ToString();
	}
}
