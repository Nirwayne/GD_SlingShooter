using UnityEngine;
using System.Collections;

public class goal : MonoBehaviour {

	public static bool goalMet;

	void OnTriggerEnter(Collider other) {
		if(other.tag == "projectile") {
			goalMet = true;
			Color c = this.GetComponent<Renderer>().material.color;
			c.a = 1;
			this.GetComponent<Renderer>().material.color = c;
		}
	}
}
