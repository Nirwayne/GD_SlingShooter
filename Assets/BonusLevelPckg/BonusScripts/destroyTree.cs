using UnityEngine;
using System.Collections;

public class destroyTree: MonoBehaviour {

	public GameObject treegoalEvent;
	public int reward = 400;
	
	public AudioClip[] Bling;
	private AudioSource this_source;
	private bool treegoalMet;
	
	
	void Awake() {
		this_source = GetComponent<AudioSource>();
		treegoalEvent.SetActive (false);
		treegoalMet = false;
	}
	

	void OnTriggerEnter(Collider other) {
		if(other.tag == "ground" && !treegoalMet) {
			treegoalMet = true;
			treegoalEvent.SetActive(true);

			BonusGamecontroller.s.AddScore(reward);
			this_source.pitch = 2.5f;
			for (int i = 0; i < Bling.Length; i++) {
				this_source.PlayOneShot(Bling[i],0.5f);
				
			}
			Destroy (this, 5);
		}
	}
}
