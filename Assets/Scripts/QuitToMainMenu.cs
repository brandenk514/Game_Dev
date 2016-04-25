using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuitToMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Level(){
		SceneManager.LoadScene ("Title Screen");
	}
}
