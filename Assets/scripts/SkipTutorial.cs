using UnityEngine;
using System.Collections;

public class SkipTutorial : MonoBehaviour {

	public void skip (int Level) {
		Application.LoadLevel(Level);
	}

}
