using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Startscreen : MonoBehaviour {

	private bool slideOK;
	public float sliding = 0.04f;
	private Color newCol;

	void Start() {
		StartCoroutine(Example());
		slideOK = false;
		newCol =this.GetComponent<Image>().color;
	}
	void FixedUpdate() {
		if (slideOK) {
			newCol.a -= sliding;
			this.GetComponent<Image>().color = newCol;
		}
		if (newCol.a < 0){
			this.gameObject.SetActive(false);
		}
	}

	IEnumerator Example() {
		yield return new WaitForSeconds(5);
		slideOK = true;

	}



}
