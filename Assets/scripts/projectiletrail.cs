using UnityEngine;
using System.Collections;

public class projectiletrail : MonoBehaviour {
	public static projectiletrail S;
	// public inspector fields
	public Color c1;
	public Color c2;
	public float mindist = 0.1f;
	// private fields
	private LineRenderer line;
	private GameObject _poi;
	private Vector3 lastpoint;
	private int pointscount;

	void Awake() {
		S = this;
		line = this.GetComponent<LineRenderer>();
		pointscount = 0;
		line.enabled = false;
		line.SetColors (c1, c2);
	}
	
	public GameObject poi {
		get{
			return _poi;
		}
		set {
			// use "value", to access the value to set the property to
			_poi = value;
			// if poi is set to sth new reset linerenderer
			if (_poi != null) {
				line.enabled = false;
				pointscount = 0;
				line.SetVertexCount(0);
			}
		}
	}
	
	void FixedUpdate() {
		// if poi is not set but pointoi is "projectile" set poi = pointoi
		if (poi == null) {
			if (followcam.s.pointoi && followcam.s.pointoi.tag == "projectile") {
				poi = followcam.s.pointoi;
				return;
			} else {
				return;
			}
		}
		Addpoint();
		if (poi.GetComponent<Rigidbody>().IsSleeping()){
			poi = null;
		}
	}

	public void clear() {
		_poi = null;
		line.enabled = false;
		pointscount = 0;
		line.SetVertexCount (0);
	}

	public void Addpoint() {
		// calculates position and sets point
		Vector3 pt = _poi.transform.position;
		if (pointscount > 0 && (pt - lastpoint).magnitude < mindist) {
			return;
		}
		if (pointscount == 0) {
			line.enabled = true;
		}
		pointscount++;
		line.SetVertexCount (pointscount);
		line.SetPosition (pointscount - 1, pt);
		lastpoint = pt;
	}
}
