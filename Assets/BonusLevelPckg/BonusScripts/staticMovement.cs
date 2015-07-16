using UnityEngine;
using System.Collections;

public class staticMovement : MonoBehaviour {
	public float moveSpeed = 0.2f;
	public Vector3 moveDirection;
	public float length = 10f;

	private float counting;

	void Start() {
		counting = 0f;
		moveDirection.x = (moveDirection.x*moveSpeed);
		moveDirection.y = (moveDirection.y*moveSpeed);
		moveDirection.z = (moveDirection.z*moveSpeed);

	}

	void FixedUpdate() {
		transform.position += moveDirection;

		counting += moveSpeed;

		if (counting > length || counting < 0) {
			moveDirection = -moveDirection;
			moveSpeed = -moveSpeed;

		}
	}


}
