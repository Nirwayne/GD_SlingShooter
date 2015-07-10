using UnityEngine;
using System.Collections;

public class ParticleTest : MonoBehaviour {
	public static ParticleTest s;
	public Vector3 rotationVector;
	public float rotationZspeed = 5.5f;
	private GameObject myparent;

	void Start() {
		myparent = transform.parent.gameObject;
		s = this;
	}
	void FixedUpdate() {
		transform.position = myparent.transform.position;
		transform.Rotate (rotationVector * rotationZspeed);
	}
}
