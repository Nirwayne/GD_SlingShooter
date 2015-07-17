using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class MuteButtonGraphic : MonoBehaviour {

	public Sprite Mute;
	public Sprite notMute; 

	void Update() {
		if (gamecontroller.isMuted) {
			this.GetComponent<Image>().sprite = Mute;
		} else {
			this.GetComponent<Image>().sprite = notMute;
		}

	}

}
