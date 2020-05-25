using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadTitleFromGameClear : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    void Awake(){
        int score = PlayerPrefs.GetInt("score",0);
        int highScore = PlayerPrefs.GetInt("high score", 0);
        
        this.scoreText.text = "Your Score : " + score.ToString();
        this.highScoreText.text = "High Score : " + highScore.ToString();
        if (highScore < score) {
            PlayerPrefs.SetInt("high score", score);
        }

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
