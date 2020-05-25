using UnityEngine;
using System.Collections;

/* 球打つクラス  Playerにアタッチ*/

public class Bullet : MonoBehaviour {
	//連射阻止用のカウンター
	private int count = 0;
	//misile prefab
	public GameObject misile;
	//bullet prefab
	public GameObject bullet;
	//弾丸の発射点
	public Transform muzzle;
	//弾丸の速度
	public float speed = 1000;
	//ミサイルの弾数
	private int maxMisile = 6;
	//弾丸発射音
	public AudioClip bulletSound;
	private AudioSource bulletAs;
	//ミサイル発射音
	public AudioClip misileSound;
	private AudioSource misileAs;
	//Playerクラスの参照
	private Player player;

	void Start(){
		this.bulletAs = GetComponent<AudioSource> ();
		this.misileAs = GetComponent<AudioSource> ();
		this.player = GetComponent<Player> ();
	}

	void Update () {
		//Fire1 が押された時
		if (Input.GetButtonDown("Fire1") && this.count <= 1) {
			this.count += 15;
			//弾丸の複製
			GameObject bullets = GameObject.Instantiate (bullet)as GameObject;
			//銃弾は2秒後に破壊
			Destroy (bullets, 2);

			//銃弾を発射する力
			Vector3 force;
			force = this.gameObject.transform.forward * (speed + player.getMoveSpeed ());
			//Rigidbodyに力を加えて発射
			bullets.GetComponent<Rigidbody> ().AddForce (force);
			//弾丸の位置を調整
			bullets.transform.position = muzzle.position;
			//発射音再生
			bulletAs.PlayOneShot(bulletSound);
		}

		if (Input.GetButtonDown ("Fire2") && maxMisile > 0) {
			maxMisile--;
			//一番近い敵を発見し、一時保存
			ApperEnemy ae = GameObject.Find ("Boss").GetComponent<ApperEnemy>();
			GameObject tmpEnemy = ae.EnemySearch ();

			//ミサイルの複製
			GameObject misiles = GameObject.Instantiate (misile)as GameObject;

			//作ったミサイルのスクリプトを取得し, フィールドに直接アクセス. さっきの一番近い敵を格納.
			Misile tmpMisile = misiles.GetComponent<Misile>();
			tmpMisile.target = tmpEnemy;

			//5秒後に破壊
			Destroy (misiles, 5);

			//ミサイルを発射位置まで移動
			misiles.transform.position = muzzle.position;
			//発射音再生
			misileAs.PlayOneShot(misileSound);
		}

		if (this.count > 0) {
			this.count -= 1;
		}
	}

	public int getMisile(){
		return maxMisile;
	}

	public void stop(){
		enabled = false;
	}
}