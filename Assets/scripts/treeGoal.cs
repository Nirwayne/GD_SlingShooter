﻿using UnityEngine;
using System.Collections;

public class treeGoal : MonoBehaviour {
	public static treeGoal s;

	public GameObject treegoalEvent;
	public int reward = 400;
	
	public AudioClip[] Bling;
	private AudioSource this_source;
	private bool treegoalMet;
	
	
	void Awake() {
		this_source = GetComponent<AudioSource>();
		treegoalEvent.SetActive (false);
		treegoalMet = false;
		s = this;
	}
	

	void OnTriggerEnter(Collider other) {

		if(other.tag == "ground" && !treegoalMet) {
			treegoalMet = true;
			treegoalEvent.SetActive(true);

			gamecontroller.S.addToScore(reward);
			this_source.pitch = 1f;
			for (int i = 0; i < Bling.Length; i++) {
				this_source.PlayOneShot(Bling[i],0.5f);
				
			}
		}
	}
}
