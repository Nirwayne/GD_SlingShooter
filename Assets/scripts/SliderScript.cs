using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {

	public static float volume;
	void Awake() {
		GetComponent<Slider>().value = volume;
	}
	void Update() {
		volume = GetComponent<Slider>().value;
	}
}
