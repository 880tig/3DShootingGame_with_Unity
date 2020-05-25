using UnityEngine;
using System.Collections;

public class MidBossDamage : MonoBehaviour {

	public int HP = 10;
	private ScoreBoard scoreBoad;

	void OnCollisionEnter(Collision col){
		HP -= 10;
		if (col.gameObject.CompareTag ("Misile")) {			
			scoreBoad = GameObject.Find ("Player").GetComponentInChildren<ScoreBoard> ();
			scoreBoad.scorePlus (20);

			Destroy (gameObject.transform.parent.gameObject);	
		}
		//弾が当たるとダメージ、体力がなくなると破壊
		if (HP <= 0) {
			scoreBoad = GameObject.Find ("Player").GetComponentInChildren<ScoreBoard> ();
			scoreBoad.scorePlus (20);

			Destroy (gameObject.transform.parent.gameObject);
		}
	}
}
