using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	public void LvSelect (int level) {
		Application.LoadLevel(level);
	}
}
