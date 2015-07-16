using UnityEngine;
using System.Collections;

public class blueItem_get : MonoBehaviour {

	void OnTriggerEnter (Collider other) {

		if (other.tag == "Player") {
			// activate other special abilities
			Abilities.s.activateBlue();
			BonusGamecontroller.s.blueActive();
			Destroy(this.gameObject);
		}
	}



}
