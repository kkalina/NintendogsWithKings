using UnityEngine;
using System.Collections;

public class PeasantStabilizer : MonoBehaviour {

    public Rigidbody core;
    public float stabilizerForce = 10f;

	// Use this for initialization
	void Start () {
        //rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        core.AddForce(Vector3.up * stabilizerForce);
	}
}
