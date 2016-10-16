using UnityEngine;
using System.Collections;

public class Stabalize : MonoBehaviour {


    public Rigidbody core;
    public float stabilizerForce = 238f;
    public float max_speed = 100f;

    // Use this for initialization
    void Start () {
        core.AddForce(Vector3.up * stabilizerForce);
    }
	
	// Update is called once per frame
	void Update () {
        if (core.velocity.x < max_speed && 
            core.velocity.y < max_speed && 
            core.velocity.z < max_speed) {
            core.AddForce(Vector3.up * stabilizerForce);
        }
    }
}
