using UnityEngine;
using System.Collections;

public class shootScript : MonoBehaviour {

	LineRenderer Line;
	//public float range = 100f;
	public float hitForce = 20f;
	public GameObject projectile;
	public float velocity;

	void Start() {
		//Line = gameObject.GetComponent<LineRenderer>();
		//Line.enabled = false;
		Cursor.visible = false;
	}


	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			shoot ();
			//StopCoroutine("FireLaser");
			//StartCoroutine("FireLaser");
		}
	}

	void shoot() {
		GameObject throwthis;
		Vector3 direction = transform.forward;
		direction.x *= velocity;
		direction.y *= velocity;
		direction.z *= velocity;
		throwthis = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		throwthis.GetComponent<Rigidbody>().AddRelativeForce(direction); 
	}
	

}















