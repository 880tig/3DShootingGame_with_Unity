using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    private float speed;
    private float HP;
    private float MaxHP;
    private CharacterController cc;
    private int toRuteNumber;
    private ApperEnemy ae;
	private Transform[] toRutes;
	private Vector3 toVec;
    
	void Awake () {
        speed = 0.01f;
		MaxHP = 5f;
		HP = MaxHP;
		ae = GetComponent<ApperEnemy> ();
		cc = GetComponent<CharacterController> ();

		toRutes = new Transform[10];
		getRutes();
		toRuteNumber = 0;
	}

	void Update(){
		toVec = toRutes [toRuteNumber].position - transform.position;


		if (Vector3.Distance (transform.position, toRutes [toRuteNumber].position) < 0.5f) {
			if (toRuteNumber < toRutes.Length) {
				toRuteNumber++;
				transform.LookAt (toRutes [toRuteNumber]);
				transform.rotation *= Quaternion.AngleAxis (-90, Vector3.up);
			}
		}

		if (toRuteNumber == (toRutes.Length - 1)) {
			toRuteNumber = 0;
		}

		if (40 < Vector3.Distance (transform.position, toRutes [toRuteNumber].position)) {
			toVec /= 2;
		}
		cc.Move (toVec * speed);
	}

	public float getMaxHP(){
		return MaxHP;
	}

	public float getHP(){
		return HP;
	}

	public void damage(){
		if (ae.judgeBosses()) {
			HP--;
		}
	}

	private void getRutes(){
		for (int i = 0; i < toRutes.Length; i++) {
			toRutes [i] = GameObject.Find ("Rute" + i).transform;
		}
	}

	public void stop(){
		enabled = false;
	}

}
