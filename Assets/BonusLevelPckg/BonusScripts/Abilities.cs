using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Abilities : MonoBehaviour {
	public static Abilities s;

	public float jumpHeight = 30.0f;
	public float walkSpeed = 10;
	public float runSpeed = 30;
	private float oldJumpHeight = 10;
	private float oldWalkSpeed = 5;
	private float oldRunSpeed = 10;
	bool gotAbilities;
	bool activateAbilities;
	FirstPersonController fpc;

	void Start () {
		s = this;
		gotAbilities = false;
		activateAbilities = false;
		fpc = GetComponent<FirstPersonController>();
	}
	public void activateBlue() {
		fpc.m_JumpSpeed = jumpHeight;
	}
	public void activateRed() {
		gotAbilities = true;
	}

	void FixedUpdate() {
		if (gotAbilities) {
			// enables or disables the special abilities
			if (Input.GetKeyDown("f") && !activateAbilities){
				activateAbilities = true;
				fpc.m_RunSpeed = runSpeed;
				fpc.m_WalkSpeed = walkSpeed;
				fpc.m_JumpSpeed = jumpHeight;
			} else if (Input.GetKeyDown("f")){
				activateAbilities = false;
				fpc.m_RunSpeed = oldRunSpeed;
				fpc.m_WalkSpeed = oldWalkSpeed;
				fpc.m_JumpSpeed = oldJumpHeight;
			}
		}
	}


}
