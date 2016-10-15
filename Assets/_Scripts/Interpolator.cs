using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interpolator : MonoBehaviour {
	public List<Transform>	points;
	public float 			u;
	public float			duration = 2;
	public float			eccentricity = 0.15f;

	// Update is called once per frame
	void Update () {
		u = (Time.time / duration)%1f;
//		u = u*u*u*u*u*u;
//		u = 1 - (1-u)*(1-u);
		u = u + Mathf.Sin(u*Mathf.PI*2) * eccentricity;

//		Vector3 p0 = points[0].position;
//		Vector3 p1 = points[1].position;
//		Vector3 p2 = points[2].position;
//		Vector3 p01 = (1-u)*p0 + u*p1;
//		Vector3 p12 = (1-u)*p0 + u*p1;
//		Vector3 p012 = (1-u)*p01 + u*p12;

		transform.position = Bezier (points, u);
	}

	Vector3 Bezier(List<Transform> lT, float u, int i0=0, int i1=-1) {
		if (i1 == -1) i1 = lT.Count-1;
		if (i0 == i1) return lT[i0].position;
		Vector3 p0 = Bezier (lT, u, i0, i1-1);
		Vector3 p1 = Bezier (lT, u, i0+1, i1);
		Vector3 p01 = (1-u)*p0 + u*p1;
		return p01;
	}

}






