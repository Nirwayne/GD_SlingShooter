using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class slingshot : MonoBehaviour {
	public static slingshot s;

	// Inspector variables
	// sound variables
	public AudioClip shootSound1;
	public AudioClip shootSound2;
	private AudioSource source;
	private float volLowRange = 0.5f;
	private float volHighRange = 1.0f;
	// slingshot variables
	public GameObject seat;
	public GameObject prefabprojectile;
	public float velocitymult = 4.0f;
	public GameObject launchpoint;
	// private variables
	//private GameObject launchpoint;
	private bool aimingmode;
	private GameObject projectile;
	private Vector3 launchposition;
	// limits projectiles in scene
	private GameObject[] projectiles = new GameObject[5];
	private int projectileCounter;
	private float maxmag;
			
			
	void Awake() {

		launchpoint.SetActive(false);
		launchposition = launchpoint.transform.position;

		source = GetComponent<AudioSource>();
		projectileCounter = 0;

		maxmag = this.GetComponent<SphereCollider>().radius;
	}
	void OnMouseEnter() {
		launchpoint.SetActive(true);
	}
	void OnMouseExit() {
		launchpoint.SetActive(false);
	}
	void OnMouseDown() {
		aimingmode = true;
		// instantiate a projectile at launchpoint
		projectile = Instantiate (prefabprojectile) as GameObject;
		projectile.transform.position = launchposition;
		seat.transform.position = launchposition;
		// switch off physics/gravity for now
		projectile.GetComponent<Rigidbody> ().isKinematic = true;

		projectileCounter++;
		projectiles[projectileCounter] = projectile;
	}

	void Update() {
        // check for aiming mode
        if (!aimingmode) return;

        // get mouseposition and convert to 3D
        Vector2 mousePos2D = Input.mousePosition;  // change: Vector3 --> vector2
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        mousePos3D.z = transform.position.z; // change: -camera.main.; uses mousepos3d instead of 2d
        // calculate the delta between launch position and mouse position
        Vector3 mouseDelta = mousePos3D - launchposition;
		// constrain the delta to radius of the sphere collider
      
        mouseDelta = Vector3.ClampMagnitude(mouseDelta, maxmag);
        // set projectile position to new position and fire it
        projectile.transform.position = launchposition + mouseDelta;
		Vector3 seatnew = launchposition + mouseDelta;
		seatnew.x -= 0.15f;
		seat.transform.position = seatnew;

		if (Input.GetMouseButtonUp(0)) {
            		// play shootsound
			source.PlayOneShot(shootSound1, Random.Range(volLowRange, volHighRange));
			source.PlayOneShot(shootSound2, Random.Range(volLowRange, volHighRange));

			aimingmode = false;

			seat.transform.position = launchposition;
            		projectile.GetComponent<Rigidbody>().isKinematic = false;
           		projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocitymult;
			gamecontroller.S.shotstaken++;
            		followcam.s.pointoi = projectile;
			projectiletrail.S.clear ();

        	}
		if (projectileCounter >= projectiles.Length-1) {
			projectileCounter = 0;
		}
		Destroy(projectiles[projectileCounter+1]);
	}


}
