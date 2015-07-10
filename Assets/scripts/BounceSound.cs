using UnityEngine;
using System.Collections;

public class BounceSound : MonoBehaviour {

	public AudioClip bounceSoft;
	public AudioClip bounceHard;

	private AudioSource source;
	private float lowPitchRange = 0.7f;
	private float highPitchRange = 1.3f;




	void Awake() {
		source = GetComponent<AudioSource>();
	}

	void OnCollisionEnter (Collision coll) {

		source.pitch = Random.Range(lowPitchRange, highPitchRange);

		if (coll.gameObject.layer == 8) 
			source.PlayOneShot(bounceHard, 0.2f);
		else if (coll.gameObject.layer == 9){
			source.PlayOneShot(bounceSoft, 0.2f);
		}
	}
}
