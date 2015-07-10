using UnityEngine;
using System.Collections;

public class movingclouds : MonoBehaviour {
	// inspector variables
	public GameObject prefabcloud;
	public float cloudmovespeed = 2.0f;
	public int numclouds = 30;
	public Vector3 cloudposmin;
	public Vector3 cloudposmax;
	public float cloudscalemin = 3.0f;
	public float cloudscalemax = 10.0f;
	// create an array for all the cloud prefabs
	public GameObject[] cloudprefabs;
	private GameObject[] cloudinstance;

	void Awake() {
		// create an array large enough to store all cloud instances
		cloudinstance = new GameObject[numclouds];
		// find the cloud anchor in the hierarchy
		GameObject cloudanchor = GameObject.Find("herbert");

		GameObject cloud;
		for( int i = 0; i < numclouds; i++) {
			// instantiate one random from cloudprefabs
			int prefabno = Random.Range(0, cloudprefabs.Length-1);
			cloud = Instantiate(cloudprefabs[prefabno]) as GameObject;
			// set spawnposition
			Vector3 cloudposition = Vector3.zero;
			cloudposition.x = Random.Range (cloudposmin.x, cloudposmax.x);
			cloudposition.y = Random.Range (cloudposmin.y, cloudposmax.y);
			cloudposition.z = Random.Range (cloudposmin.z, cloudposmax.z);
			// random scale, position and speed dependent from scale
			float scaleU = Random.value;
			float scaleval = Mathf.Lerp(cloudscalemin, cloudscalemax, scaleU);
			cloudposition.y = Mathf.Lerp (cloudposmin.y, cloudposmax.y, scaleU);
			cloudposition.z = 100 - 90*scaleU;
			// set missing values of cloud and finally create one
			cloud.transform.position = cloudposition;
			cloud.transform.localScale = Vector3.one * scaleval;
			cloud.transform.parent = cloudanchor.transform;
			cloudinstance[i] = cloud;
		}
	}

	void Update() {
		foreach (GameObject cloud in cloudinstance) {
			// moves every cloud by scaledefined speed
			float scaleval = cloud.transform.localScale.x;
			Vector3 cpos = cloud.transform.position;
			cpos.x -= Time.deltaTime * cloudmovespeed * scaleval;
			// puts cloud which is too far left to the right border
			if ( cpos.x < cloudposmin.x) {
				cpos.x = cloudposmax.x;
			}
			cloud.transform.position = cpos;
		}
	}
}
