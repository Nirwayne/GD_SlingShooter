using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class gamecontroller : MonoBehaviour {

	public static gamecontroller S;

	public static int levelCount = 1;
	// inspector variables
	public GameObject maincamera;
	public bool flymode;
	public GameObject slingshot;
	// UI
	public GameObject go_shotstaken;
	Text str_shotstaken;
	public int shotstaken;
	public GameObject go_score;
	Text str_score;
	public static int score;
	public int currentlevel;
	public GameObject go_currentLevel;
	Text str_currentLevel;
	public static bool isMuted;

	// privates
	// current level
	private Vector3 castlepos;
	private Vector3 slingshotpos;

	private GameObject bothPos;
	private int levelmax;

	private GameObject castle;
	private float xdifference;

	private static int oldScore;


	void Awake() {
		// instantiate variables
		S = this;
		currentlevel = Application.loadedLevel;
		//slingshot = GameObject.FindGameObjectWithTag("slingshot");
		castle = GameObject.FindGameObjectWithTag("castle");
		bothPos = new GameObject();

		Vector3 both = slingshotpos;
		slingshotpos = slingshot.transform.position;
		castlepos = castle.transform.position;
		// calculate position for "both"
		xdifference = castlepos.x - slingshotpos.x;
		both.x = xdifference/2;
		both.y = xdifference/2;
		bothPos.transform.position = both;

		//score and more
		shotstaken = 0;
		str_shotstaken = go_shotstaken.GetComponent<Text>(); 
		str_shotstaken.text="Shots taken " + shotstaken;

		str_score = go_score.GetComponent<Text> ();
		str_score.text = "Score " + score;

		str_currentLevel = go_currentLevel.GetComponent<Text>();
		str_currentLevel.text = "Level " + (currentlevel -1);
	}

	void loadlevel(int level) {

		Application.LoadLevel(level);		
	}

	void Update() {
		// update GUI
		str_shotstaken.text = "Shots taken  " + shotstaken;   
		str_score.text = "Score " + score;
		str_currentLevel.text = "Level " + (currentlevel -1);

		// update volume based on the vol slider
		if (!isMuted)
			AudioListener.volume = SliderScript.volume;

		if (Input.GetKeyDown("escape"))
		    Application.Quit ();

	}

	// used by external scripts (goals)
	public void addToScore (int adding) {
		score += adding;
	}
	public int getScore() {
		return score;
	}

	private void loadNextLevel() {
		levelCount++;
		oldScore = score;
		loadlevel(currentlevel+1);
	}

	// mute button:
	private void onMute() {
		if (!isMuted){
			AudioListener.volume = 0f;
			isMuted = true;
		}
		else if (isMuted){
			AudioListener.volume = SliderScript.volume;
			isMuted = false;
		}
	}



	public void buttons(string onclick) {
		// checks which button is clicked and what to do then
		if (flymode == false) {
			switch (onclick) {
			case ("mute"):
				onMute ();
				break;
			case ("exit"):
				Application.Quit();
				break;
			case ("reload"):
				score = oldScore;
				loadlevel(currentlevel);
				break;
			case ("aiming"):
				followcam.s.pointoi = slingshot;
				flymode = false;
				break;
			case ("next"):
				loadNextLevel();
				break;
			case "0":
				followcam.s.pointoi = slingshot;
				break;
			case "1":
				followcam.s.pointoi = bothPos;
				break;
			case "2":
				followcam.s.pointoi = castle;
				break;
			default:
				followcam.s.pointoi = slingshot;
				break;
			} 
		}else {
			switch (onclick) {
			case ("mute"):
				onMute();
				break;
			case ("exit"):
				Application.Quit();
				break;
			case ("reload"):
				score = oldScore;
				loadlevel(currentlevel);
				break;
			case ("aiming"):
				followcam.s.pointoi = slingshot;
				flymode = false;
				break;
			case ("next"):
				loadNextLevel();
				break;
			}
		}
	}
}
