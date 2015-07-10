using UnityEngine;
using System.Collections;

public class followprojectile : MonoBehaviour {
	public static followprojectile s;
	// inspector variables
	public GameObject follower;
	public float rotationZ = 5.0f;
	public float rotationangle = 0.5f;
	public Vector3 rotationnew;
	public Transform newRotation;
	// private variables
	private Vector3 destination;
	private Vector3 rotationold;

	void Awake() {
		s = this;
	}

	void FixedUpdate() {
		// if poi is tag projectile, set position to poi
		if (followcam.s.pointoi && followcam.s.pointoi.tag == "projectile") {
			destination = followcam.s.pointoi.transform.position;
			follower.transform.position = destination;     
		}
	}
}
