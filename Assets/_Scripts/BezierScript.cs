using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BezierScript : MonoBehaviour {

	public List<Transform>	points;
	public float			u = 0;
	public float			duration = 1f;
	public float			eccentricity = 0.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		u = (Time.time / duration)%1.0f;

		u = u + Mathf.Sin(u*Mathf.PI*2)*eccentricity;

		transform.position = Interp (points, u);

//		Vector3 p01 = (1-u)*points[0].position + u*points[1].position;
//		Vector3 p12 = (1-u)*points[1].position + u*points[2].position;
//		Vector3 p012 = (1-u)*p01 + u*p12;
//		transform.position = p012;
	}

	Vector3 Interp(List<Transform> lT, float u, int i0=0, int i1=-1) {
		if (i1 == -1) {
			i1 = lT.Count-1;
		}
		if (i0 == i1) {
			return (lT[i0].position);
		}
		Vector3 p0 = Interp (lT, u, i0, i1-1);
		Vector3 p1 = Interp (lT, u, i0+1, i1);
		Vector3 p01 = (1-u)*p0 + u*p1;
		return(p01);
	}
}





