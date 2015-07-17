using UnityEngine;
using System.Collections;

public class destroy_plane : MonoBehaviour {

	public Vector3 respawn = new Vector3(0, 2, 0);

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			other.transform.position = respawn;
		}
		else {
			//Destroy(other.gameObject);
		}
	}

}
