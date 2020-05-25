using UnityEngine;
using System.Collections;

/*
 * プレイヤーの動きのクラス　Playerにアタッチ
 */

public class Player : MonoBehaviour {

	/*フィールド*/
	private float moveSpeed;
	private float to_x = 0;
	private float to_y = 0;
	private CharacterController cc ;

	void Start(){
		moveSpeed = 3.0f;
		cc = GetComponent<CharacterController> ();
	}

	void Update () {
		if (Input.GetButton ("Fire3")) {
			if (moveSpeed < 24f) {
				moveSpeed++;
			}
		} else {
			if (3f < moveSpeed) {
				moveSpeed--;
			}
		}

		//方向ベクトル
		Vector3 moveDirection = new Vector3 (0, 0, 0);
		Quaternion to_rotation = new Quaternion (0, 0, 0, 0);

		//移動方向変更（左右用）
		to_x += Input.GetAxisRaw ("Mouse X");

		//上のとほぼ同じ（上下用）
		//上角　及び　下角　が90を超えるのを防ぐ
		if ((to_y + Input.GetAxisRaw ("Mouse Y")) < 90 && (to_y + Input.GetAxisRaw ("Mouse Y")) > -90) {
			to_y += Input.GetAxisRaw ("Mouse Y");
		}

		//to_y 及び to_x を使用し、向く向きを決める
		to_rotation = Quaternion.Euler (to_y, to_x, 0);
		//to_rotation 方向に向く 速度は１秒１８０度くらい
		transform.rotation = Quaternion.RotateTowards (transform.rotation, to_rotation, 180 * Time.deltaTime);
		

		//常に前には動く様になっている
		moveDirection += transform.forward * moveSpeed;

		//最終的にここで動かす
		cc.Move(moveDirection*Time.deltaTime);
	}

	public float getMoveSpeed(){
		return this.moveSpeed;
	}

	public void stop(){
		enabled = false;
	}
}
