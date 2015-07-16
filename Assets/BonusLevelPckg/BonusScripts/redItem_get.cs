using UnityEngine;
using System.Collections;

public class redItem_get : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {

			// activate other special abilities
			Abilities.s.activateRed();
			BonusGamecontroller.s.redActive();
			Destroy(this.gameObject);
		}
	}
}
