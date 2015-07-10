using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {


	Text str_score;
	
	void Awake(){
		str_score = GetComponent<Text>();
	}
	void Update() {
		str_score.text = ("Your Score " + gamecontroller.score);
	}

	public void exit(bool onclick) {
		if (onclick)
			Application.Quit();
	}
}
