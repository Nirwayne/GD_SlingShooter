using UnityEngine;
using System.Collections;

public class yellowItem : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {

			BonusGamecontroller.s.yellowActive();
			Destroy(this.gameObject);
		}
	}


}
