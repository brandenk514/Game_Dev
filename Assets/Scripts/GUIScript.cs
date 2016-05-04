using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScript : MonoBehaviour {

	private comp_cs player;
	private Canvas canvas;
	private Text scoreText, messageText;
	//private float score = 0;
	private Slider handle;
	public int score;
	 

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<comp_cs> ();
		scoreText = GameObject.FindGameObjectWithTag ("Score").GetComponent<Text>();
		messageText = GameObject.FindGameObjectWithTag ("Message").GetComponent<Text>();
		handle = FindObjectOfType<Slider> ();
		handle.value = player.health;
	}
	
	// Update is called once per frame
	void Update () {

		handle.value = player.health;
		score = Mathf.RoundToInt (player.transform.position.z);

		//score += Time.deltaTime;
		scoreText.text = "Score: " + score;
		//canvas.GetComponentsInChildren<TextMesh>();

		if (player.health < 20) {
			messageText.text = "Your health is low... Eat some food!";
		}
	}
}
