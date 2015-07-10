using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class activateNextLevelButton : MonoBehaviour {
	private int level;

	void Awake() {
		this.GetComponent<Button>().interactable = false;
	}

	void Start() {
		level = gamecontroller.S.currentlevel;
	}

	void Update() {
		if (gamecontroller.score >= level * 3000f) {
			this.GetComponent<Button>().interactable = true;
		}
	}

}
