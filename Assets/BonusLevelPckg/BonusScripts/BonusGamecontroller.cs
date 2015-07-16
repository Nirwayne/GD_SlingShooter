using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BonusGamecontroller : MonoBehaviour {
	public static BonusGamecontroller s;

	// canvas with: countdown, score, ItemsGot ( blue, red)
	public GameObject go_objective;
	private Text txt_objective;
	private string objective;

	public GameObject blueIcon;
	private Image img_blueIcon;

	public GameObject redIcon;
	private Image img_redIcon;

	public GameObject go_Score;
	private Text txt_Score;
	private int score;
	public GameObject go_countdown;
	private Text txt_countdown;
	private int countdown;

	public GameObject trees;


	void Awake() {
		s = this;

		img_blueIcon = blueIcon.GetComponent<Image>();
		img_redIcon = redIcon.GetComponent<Image>();

		txt_Score = go_Score.GetComponent<Text>();
		txt_objective = go_objective.GetComponent<Text>();
		txt_countdown = go_countdown.GetComponent<Text>();

		objective = "Find the blue item";
		go_Score.SetActive(false);
		go_countdown.SetActive(false);
		trees.SetActive(false);
	}
	
	void Update() {
		// Update Score, Countdown, Objective
		txt_Score.text = "Score " + score;
		txt_countdown.text = "" + countdown;
		txt_objective.text = objective;

	}

	public void blueActive() {
		// set blueIcon image to full opacity
		Color fullAlpha = img_blueIcon.color;
		fullAlpha.a = 1f;
		img_blueIcon.color = fullAlpha;

		objective = "Now find the red item";

	}
	public void redActive() {
		// set redIcon image to full opacity
		Color fullAlpha = img_redIcon.color;
		fullAlpha.a = 1f;
		img_redIcon.color = fullAlpha;

		objective = "Activate the yellow item";
	}
	public void yellowActive() {
		StartCoroutine(activatedYellow());
	}

	IEnumerator activatedYellow() {
		// enable GameObject with trees
		trees.SetActive(true);

		go_countdown.SetActive(true);
		objective = "Trees are destroyed short after they hit the ground \n or when they fall off from the arena.";
		
		// wait 5 secs
		countdown = 5;
		StartCoroutine(countdownCounter());
		yield return new WaitForSeconds(5);

		objective = "Destroy as many trees as you can within the timelimit";
		//set countdown to 60 seconds, add score to canvas
		countdown = 60;
		go_Score.SetActive(true);
	}


	IEnumerator countdownCounter () {
		if (countdown < 0) {
			StopCoroutine(countdownCounter());
			// fade to gameover screen
			// load endscreen

		}
		yield return new WaitForSeconds(1);
		countdown--;
		StartCoroutine(countdownCounter());

	}

	public void AddScore(int reward) {
		score += reward;
		print (score);
	}


}
