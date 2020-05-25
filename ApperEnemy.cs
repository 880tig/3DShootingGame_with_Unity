using UnityEngine;
using System.Collections;

/* 敵出現用のクラス　敵が出てくるとこにアタッチ */
/* 出てくるとこは　GameObject -> Empty で作るのがオススメ*/

public class ApperEnemy : MonoBehaviour {

	public GameObject MidBoss; 	//敵キャラのプレハブ
	public GameObject[] Bosses; //敵キャラを入れておく配列(上限は10の予定)
	public int gateMax = 5;		//出現ゲートの数
	public int max = 5; 		//敵の量の上限
	private float currentTime;  //現在時刻
	private float apperTime = 15;  //敵の出現間隔
	private int[] gateCounter;  //同じゲートから敵が出てかぶらない様にする配列
	private int[] conect;  		//gateCounter と Bosses を連携させるために必要

	void Start(){
		Bosses = new GameObject[max];
		for (int i = 0; i < Bosses.Length; i++) {
			Bosses [i] = null;
		}
		currentTime = 0.0f;

		gateCounter = new int[gateMax];
		conect = new int[max];

		for (int i = 0; i < gateCounter.Length; i++) {
			gateCounter [i] = -1;
		}

		for (int i = 0; i < max; i++) {
			conect [i] = -1;
		}
		apper2 ();
		apper2 ();
		apper2 ();
		apper2 ();
		apper2 ();
	}

	//敵がいなくなったら発動する
	void Update () {
		currentTime += Time.deltaTime;

		if (currentTime > apperTime) {
			apper2 ();
			currentTime = 0.0f;
		}

	}

	//敵の配列をスキャンし、nullの配列に敵を格納
	public void apper(){
		for (int i = 0; i < Bosses.Length; i++) {

			if (Bosses [i] == null) {
				//敵を作って格納
				Bosses [i] = GameObject.Instantiate (MidBoss);
				//敵が出現するゲームオブジェクトの位置まで移動
				string gate1 = "Gate1";
				Bosses [i].transform.position = GameObject.Find(gate1).transform.position + Vector3.up * 10 + Vector3.left * (i-2) * 20;

			}
		}
	}

	//selectGate() で使う用に、出現前に gateCounter と conect の値を設定する
	//その後、null の Bosses 配列に敵を生成し、selectGate() で選んだゲートから敵を出す
	public void apper2(){

		for (int j = 0; j < Bosses.Length; j++) {
			if (Bosses [j] == null) {
				if (conect [j] == -1) {
					continue;
				}
				gateCounter [conect [j]] = -1;
				conect [j] = -1;
			}
		}

		for (int i = 0; i < Bosses.Length; i++) {
			if (Bosses [i] == null) {
				Bosses [i] = GameObject.Instantiate (MidBoss);
				Transform temp = GameObject.Find (selectGate (i)).transform;
				Bosses [i].GetComponent<MidBoss> ().setGate (temp);
				Bosses [i].transform.position = temp.position;
				break;
			}
		}
	}

	//生成した敵の配列要素と同じ conect の配列要素に、その敵が出現した gateCounter を保存し、1(ON) にする
	//毎回に gateCounter をチェックして gateCounter が -1(OFF) のゲートを選択する
	//（ここでの要素配列は配列の番号を指し、gateCounter はゲート番号と同じである。）
	public string selectGate(int arg){
		int key;

		for (;;) {
			key = Random.Range (1, (gateMax + 1));
			if (gateCounter [key - 1] == -1) {
				gateCounter [key - 1] = 1;
				break;
			}
		}
				
		conect [arg] = key - 1;

		return "Gate" + key;
	}
		

	//距離100以内の敵で最も近い敵を発見する
	public GameObject EnemySearch(){
		float distance = 100;  //索敵範囲
		float tmpD;  //距離の仮置き
		GameObject tmpG = null;  //ゲームオブジェクトの仮置き
		Vector3 playerPos = GameObject.Find ("Player").transform.position;  //プレイヤーの位置(ベクトル並感)

		for (int i = 0; i < Bosses.Length; i++) {

			if (Bosses [i] == null) {
				continue;
			}
			else{ 
				tmpD = Vector3.Distance (playerPos, Bosses [i].transform.position);
				if (distance > tmpD) {
					distance = tmpD;
					tmpG = Bosses [i];
				}
			}
		}
		return tmpG;  //tmpG の初期値は null なので見つからなければ null が返る
	}

	public bool judgeBosses(){
		for (int i = 0; i < Bosses.Length; i++) {
			if (Bosses [i] != null) {
				return false;
			}
		}
		return true;
	}

	public void stop(){
		enabled = false;
	}
}
