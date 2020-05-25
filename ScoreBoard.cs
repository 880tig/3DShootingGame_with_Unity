using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* スコアボード用のクラス MainCameraにアタッチ */

public class ScoreBoard : MonoBehaviour {

	public Text scoreText;
	private int score = 0;
	private float currentTime;
	private Bullet bullet;

	//はじめは 0から
	void Start () {
		this.bullet = GetComponentInParent<Bullet> ();
		currentTime = 300;
		scoreText.text = "Time: " + currentTime.ToString ();
	}

	public void scorePlus(int score){
		this.score += score;
	}

	void Update () {
		
		currentTime -= Time.deltaTime;
		scoreText.text = "Score: " + score.ToString () + " / Time: " + currentTime.ToString () + "\n残りミサイル数　" + bullet.getMisile ();
		if (currentTime <= 0) {
			this.GameOver ();
		}
	}

	private void GameOver(){
		SceneManager.LoadScene ("GameOver");
	}

	public void GameClear() {
        PlayerPrefs.SetInt("score", this.score);
        PlayerPrefs.Save();
    }
}
