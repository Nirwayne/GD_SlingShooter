using UnityEngine;
using System.Collections;

public class destroy_trees : MonoBehaviour {
	public int reward = 300;

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "tree") {
			// later: addscore on tree prefab
			BonusGamecontroller.s.AddScore(reward);
			Destroy (other.gameObject, 5);

		}
	}
}
