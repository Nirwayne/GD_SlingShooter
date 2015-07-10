using UnityEngine;
using System.Collections;

public class followcam : MonoBehaviour {
    	public static followcam s; 
	// public fields
   	public GameObject pointoi;
	public Vector2 minxy;
   	public float sleepTolerance = 0.1f;
   	public float easing = 0.05f;

    Rigidbody rBody;
	// private fields
	private float camx;
	private float camz = -10.0f;
	public Vector3 destination;

    void Awake() {
        s = this;
        destination = this.transform.position;
        
    }



    void FixedUpdate() {
		if (pointoi && pointoi.tag == "projectile") {
			destination = pointoi.transform.position;
			gamecontroller.S.flymode = true;
			rBody = pointoi.GetComponent<Rigidbody>();
			rBody.sleepThreshold = sleepTolerance;

			if (rBody.IsSleeping ()) {
				pointoi = gamecontroller.S.slingshot;
				gamecontroller.S.flymode = false;
				return;
			} 
		}
		if (pointoi) { 
			destination = pointoi.transform.position;
		// calculates a smoth delay to the pointoi
		destination.z = camz;
        	destination.x = Mathf.Max(minxy.x, destination.x);
        	destination.y = Mathf.Max(minxy.y, destination.y);
        	destination = Vector3.Lerp(transform.position, destination, easing);

        	transform.position = destination;
        	this.GetComponent<Camera>().orthographicSize = 8 + destination.y;
		}
    }
}
