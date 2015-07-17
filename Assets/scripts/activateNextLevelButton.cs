using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class activateNextLevelButton : MonoBehaviour {
	private int level;

	void Awake() {
		this.GetComponent<Button>().interactable = false;
	}

	void Start() {
		level = (gamecontroller.levelCount);
	}

	void Update() {
		int myScore = gamecontroller.score;
		if ((myScore / level) >= 3000) {
			this.GetComponent<Button>().interactable = true;
		}
	}

}
