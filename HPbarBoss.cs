using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * BossのHPを管理するクラス
 * Bossにアタッチ 
 */
public class HPbarBoss : MonoBehaviour {
    
	private float count;
	private Slider hpSlider;
	private float maxHp;
	private Boss boss;

	void Start () {
		boss = GetComponent<Boss> ();
		hpSlider = GetComponentInChildren<Slider> ();
		maxHp = boss.getMaxHP();
		hpSlider.maxValue = 100f;
		hpSlider.value = 100f;
		count = maxHp;
	}
	void Update () {
		//transform.rotation = rotateCamera.transform.rotation;

		float countNow = boss.getHP();
		if (countNow != count) {
			hpSlider.value = countNow / maxHp * 100f;
			count = countNow;
		}

		if (countNow <= 0) {
			SendMessage ("stop");
			Invoke ("GameClear", 0.5f);
		}
	}

	private void GameClear(){
        Camera.main.gameObject.GetComponent <ScoreBoard>().GameClear();
		SceneManager.LoadScene ("GameClear");
	}
}
