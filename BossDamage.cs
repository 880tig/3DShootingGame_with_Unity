using UnityEngine;
using System.Collections;

public class BossDamage : MonoBehaviour {

	private Boss boss;
	// Use this for initialization
	void Start () {
		boss = GameObject.Find ("Boss").GetComponent<Boss> ();
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Player") {
			return;
		}
		boss.damage ();
	}
}
