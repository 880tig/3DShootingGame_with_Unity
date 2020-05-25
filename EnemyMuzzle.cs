using UnityEngine;
using System.Collections;

/* 敵の発射口にアタッチ */
/* 発射口は敵の子要素 */

public class EnemyMuzzle : MonoBehaviour {

	private Transform target;
	//Updateでの回数制御
	private int flag = 0;

	void LateUpdate () {
		if (flag == 0) {
			target = GameObject.Find ("Player").transform;
			flag++;
		}
		Vector3 relativePos = target.position - transform.position;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (relativePos), Time.deltaTime);
	}

	public void stop(){
		enabled = false;
	}
		
}
