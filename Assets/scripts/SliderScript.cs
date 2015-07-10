using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {
	public static SliderScript s;


	public float volume;
	void Awake() {
		s = this;
	}
	void Update() {
		volume = this.GetComponent<Slider>().value;
	}
}
