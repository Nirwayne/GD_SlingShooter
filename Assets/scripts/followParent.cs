using UnityEngine;
using System.Collections;

public class followParent : MonoBehaviour {


	void Update () {
		transform.position = transform.parent.transform.position;
	}
}
