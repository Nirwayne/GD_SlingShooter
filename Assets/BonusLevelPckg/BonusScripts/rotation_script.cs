using UnityEngine;
using System.Collections;

public class rotation_script : MonoBehaviour {

	public float RotationSpeed = 2.0f;

	void Awake() {

	}

	void FixedUpdate() {
		transform.Rotate (Vector2.up * RotationSpeed);
	}

}
