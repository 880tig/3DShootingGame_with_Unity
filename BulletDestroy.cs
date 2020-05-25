using UnityEngine;
using System.Collections;

/* 弾が何かに当たると消える　弾にアタッチ*/
/* 弾はプレハブであること前提 */

public class BulletDestroy : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		Destroy (gameObject);
	}
}
