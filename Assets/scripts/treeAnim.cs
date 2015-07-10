using UnityEngine;
using System.Collections;

public class treeAnim : MonoBehaviour {

	Animator anim;

	void Awake() {
		anim = GetComponent<Animator>();
		StartCoroutine (waiting());
	}

	void Update() {

	}

	IEnumerator waiting() {
		while (true)
		{
		yield return new WaitForSeconds(3);
		Animate();
		}
	}

	void Animate (){
		float rnd = Random.Range(0f,1f);
		bool mychange;
		if (rnd >= 0.5f)
			mychange = true;
		else
			mychange = false;


		anim.SetBool ("change", mychange);
	}
}
