using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BonusGamecontroller : MonoBehaviour {
	public static BonusGamecontroller s;

	// canvas with: countdown, score, ItemsGot ( blue, red)
	public GameObject blueIcon;
	private Image img_blueIcon;
	
	public GameObject redIcon;
	private Image img_redIcon;

	public GameObject yellowItem;

	public GameObject go_objective;
	private Text txt_objective;
	private string objective;

	public GameObject go_Info;
	private Text txt_Info;
	private string info;
	float newAlpha = 1f;
	float fontCounter = 30f;

	public GameObject go_Score;
	private Text txt_Score;
	public int bonusScore;


	public GameObject go_countdown;
	private Text txt_countdown;
	private int countdown;

	public GameObject trees;

	public bool lockPlayerPos;
	private Vector3 playerPos;

	private bool gameOver;

	void Awake() {
		s = this;

		img_blueIcon = blueIcon.GetComponent<Image>();
		img_redIcon = redIcon.GetComponent<Image>();

		txt_Score = go_Score.GetComponent<Text>();
		txt_objective = go_objective.GetComponent<Text>();
		txt_countdown = go_countdown.GetComponent<Text>();
		txt_Info = go_Info.GetComponent<Text>();

		info = "To lock/unlock the cursor press 'g'";
		objective = "Find the blue item";
		go_Score.SetActive(false);
		go_countdown.SetActive(false);
		trees.SetActive(false);
		yellowItem.SetActive(false);

		lockPlayerPos = false;
		gameOver = false;

		bonusScore = gamecontroller.score;
	}
	
	void FixedUpdate() {
		// Update Score, Countdown, Objective
		txt_Score.text = "Score " + bonusScore;
		txt_countdown.text = "" + countdown;
		txt_objective.text = objective;
		txt_Info.text = info;

		if (lockPlayerPos) {
			playerDetails.s.SetPlayerPosition(playerPos);
		}
		setTextcolor();
		if (gameOver)
			onGameOver();

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

		yellowItem.SetActive(true);

		objective = "Activate the yellow item";
		info = "To activate/deactivate you abilities press 'f'";
		newAlpha = 1f;
	}
	public void yellowActive() {
		StartCoroutine(activatedYellow());
	}

	IEnumerator activatedYellow() {
		lockPlayerPos = true;
		playerPos = playerDetails.s.GetPlayerPosition();
		// enable GameObject with trees
		trees.SetActive(true);

		go_countdown.SetActive(true);
		objective = "Trees are destroyed short after they hit the ground \n or when they fall off from the arena.";
		
		// wait 5 secs
		countdown = 5;
		StartCoroutine(countdownCounter());
		yield return new WaitForSeconds(5);
		lockPlayerPos = false;

		objective = "Destroy as many trees as you can within the timelimit";
		//set countdown to 60 seconds, add score to canvas
		countdown = 60;
		go_Score.SetActive(true);
	}


	IEnumerator countdownCounter () {
		if (countdown < 0) {
			gameOver = true;
			info = "Game Over";
			newAlpha = 1f;
			go_countdown.SetActive(false);

		}
		if (countdown < -5) {
			Application.LoadLevel(7);
		}
		yield return new WaitForSeconds(1);
		countdown--;
		StartCoroutine(countdownCounter());

	}

	public void AddScore(int reward) {
		bonusScore += reward;

	}

	private void setTextcolor() {
		Color newColor = txt_Info.color;
		float value = 0.002f;

		newColor.a = newAlpha;
		go_Info.GetComponent<Text>().color = newColor;
		newAlpha -= value;
	}
	void onGameOver () {
		// increse fontsize
		info = "Game Over";
		newAlpha = 1f;
		fontCounter += 0.5f;

		playerDetails.s.unlockCursor();
		gamecontroller.score = bonusScore;
		txt_Info.fontSize = (int) fontCounter;
	}



}
