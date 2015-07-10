using UnityEngine;
using System.Collections;

public class specialgoal_script : MonoBehaviour {
	public static specialgoal_script s;

	public GameObject specialgoalEvent;
	public int reward = 800;

	public AudioClip[] Bling;
	private AudioSource this_source;
	private bool specialgoalMet;


	void Awake() {
		this_source = GetComponent<AudioSource>();
		specialgoalEvent.SetActive (false);
		s = this;
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "projectile" && !specialgoalMet) {
			specialgoalMet = true;
			specialgoalEvent.SetActive(true);
			Color c = this.GetComponent<Renderer>().material.color;
			c.a = 1;
			this.GetComponent<Renderer>().material.color = c;
			gamecontroller.S.addToScore(reward);
			this_source.pitch = 3f;
			for (int i = 0; i < Bling.Length; i++) {
				this_source.PlayOneShot(Bling[i],0.5f);
		
			}
		}
	}

}
