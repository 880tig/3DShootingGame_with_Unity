using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadTitleFromGameOver : MonoBehaviour {

	void Start(){
		Invoke ("setTrue", 1);
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			SceneManager.LoadScene ("Title");
		}
	}

	private void setTrue(){
		gameObject.SetActive (true);
	}
}
