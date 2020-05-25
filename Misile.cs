using UnityEngine;
using System.Collections;

/*  ミサイルにアタッチ */
/* ミサイルはプレハブであること前提 */

public class Misile : MonoBehaviour {

	public GameObject target;
	public Transform targetTrans;

	private int flag = 0;

	void Update () {

		//null でない時 1回だけ実行
		if (flag == 0 && target != null) {
			targetTrans = target.transform;
			flag++;
		}

		//null のときは処理しない
		if (target != null) {
			Vector3 relativePos = targetTrans.position - transform.position;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (relativePos), 45 * Time.deltaTime);

			transform.Translate (Vector3.forward);
		} else {
			transform.Translate (Vector3.forward);
		}
	}

	void OnCollisionEnter(Collision col){
		Destroy (gameObject);
	}

	public void stop(){
		enabled = false;
	}
		
}
