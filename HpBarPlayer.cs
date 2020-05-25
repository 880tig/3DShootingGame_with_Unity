using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*HPバーを使いたい時のクラス　Playerにアタッチ*/

public class HpBarPlayer : MonoBehaviour {

	public float maxHP;
	private Slider slider;

	void Start () {
		//スライダーを取得する
		slider = GameObject.Find("PlayerSlider").GetComponent<Slider>();

		slider.maxValue = maxHP;
		slider.value = maxHP;

		//毎秒回復
		wait();
	}

	/*ダメージを受けた時のメソッド*/
	public void Damage(float damage){
		
		slider.value -= damage;
		if (slider.value <= 0) {
			SendMessage ("stop");
			Invoke ("GameOver", 0.5f);
		}
	}

	/*回復用メソッド*/
	public void cureParSecond(){

		if (slider.value < slider.maxValue) {
			slider.value += 5f;
		}
		wait ();
	}

	private void wait(){
		Invoke ("cureParSecond", 1);
	}

	/*被弾すると発動するメソッド　主にダメージを受ける*/
	void OnCollisionEnter(Collision col){
		Damage (10);
	}

	public void stop(){
		enabled = false;
	}

	private void GameOver(){
		SceneManager.LoadScene ("GameOver");
	}
		
}
