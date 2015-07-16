using UnityEngine;
using System.Collections;

public class playerDetails : MonoBehaviour {
	public static playerDetails s;

	private bool cursorLocked;

	void Awake() {
		s = this;
		cursorLocked = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public Vector3 GetPlayerPosition() {
		return transform.position;
	}

	void Update() {
		if (Input.GetKeyDown("g")) {
			if (cursorLocked)
				unlockCursor();
			else 
				lockCursor();
		}
	}

	void lockCursor() {
		cursorLocked = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	void unlockCursor() {
		cursorLocked = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}



}
