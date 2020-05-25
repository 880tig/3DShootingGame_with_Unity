using UnityEngine;
using System.Collections;

/* 敵の攻撃クラス 弾丸の発射口にアタッチ*/
/* 敵はプレハブであること前提 */

public class EnemyBullet : MonoBehaviour {

	//bullet prefab
	public GameObject bullet;
	//弾丸の速度
	public float speed = 100;
	//弾丸発射音
	public AudioClip bulletSound;
	private AudioSource bulletAs;

	void Start () {
		Invoke ("shoot", 5);
		bulletAs = GetComponent<AudioSource> ();
	}
		
	private void wait(){
		Invoke ("shoot", 5);
	}

	// Update is called once per frame
	private void shoot() {
		//弾丸の複製
		GameObject bullets = GameObject.Instantiate (bullet)as GameObject;
		//銃弾は2秒後に破壊
		Destroy (bullets, 20);

		//銃弾を発射する力
		Vector3 force;
		force = this.gameObject.transform.forward * speed;
		//Rigidbodyに力を加えて発射
		bullets.GetComponent<Rigidbody> ().AddForce (force);
		//弾丸の位置を調整
		bullets.transform.position = this.transform.position;
		//発射音再生
		bulletAs.PlayOneShot(bulletSound);
		wait ();
	}

	public void stop(){
		enabled = false;
	}
}
