using UnityEngine;
using System.Collections;

/* 中ボス用のクラス　中ボス(と思わしき敵)にアタッチ*/
/* 中ボス(と思わしき敵)はプレハブ前提 */

public class MidBoss : MonoBehaviour {
	
	public ScoreBoard scoreBoad;
    public Transform gate;
    private Transform target;
	private CharacterController cc;

	void Awake(){
		target = GameObject.Find ("Player").transform;
		cc = GetComponent<CharacterController> ();
	}

	void LateUpdate () {
		cc.Move ((gate.position - transform.position));

		Vector3 relativePos = target.position - transform.position;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (relativePos), Time.deltaTime);
	}

	public void setGate(Transform gate){
		this.gate = gate;
	}

	public void stop(){
		enabled = false;
	}
}
