using UnityEngine;
using System.Collections;

public class enemy1 : MonoBehaviour {

	public int maxHP = 200;
	private int myHP;
	public int hitDMG = 20;
	NavMeshAgent nav; 
	Vector3 playerPos;
	
	void Start() {
		myHP = maxHP;
		nav = GetComponent <NavMeshAgent>();
		playerPos = playerDetails.s.GetPlayerPosition();
		nav.destination = playerPos;
	}

	void Update() {
		// constantly get player position and assign it to the nav mesh 
		playerPos = playerDetails.s.GetPlayerPosition();
		nav.destination = playerPos;
		enemyMove();
	}

	void enemyMove() {
		//Vector3 playerPos = playerDetails.s.GetPlayerPosition();
		//Vector3 myPos = transform.position;
		//Vector3 moveVec = myPos - playerPos;
		//nav.destination = playerPos;
	}

	void OnCollisionEnter (Collision other) {
		if (other.collider.tag == "projectile") {

			myHP -= hitDMG;
			if (myHP <= 0)
				destroyMe();
		}
	}

	void destroyMe() {
		Destroy(this.gameObject);
	}
	// destroy when HP is below 0 = check
	// make it move towards player
}
