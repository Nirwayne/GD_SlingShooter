using UnityEngine;
using System.Collections;

public class spawnProjectiles : MonoBehaviour {

	public GameObject projectile;
	public float velocity;
	private GameObject throwthis;

	void Awake() {

	}
	void FixedUpdate() {
		// update projectile position
		if (Input.GetMouseButtonDown(0)) {
			throwthis = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
			throwthis.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0,velocity)); 
		}
	}
}
