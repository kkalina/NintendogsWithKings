using UnityEngine;
using System.Collections;

public class debirs : MonoBehaviour {

    private float startTime = 0f;
    public float lifeTime = 10f;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if(Time.time > startTime + lifeTime)
        {
            this.gameObject.GetComponent<Rigidbody>().Sleep();
        }
	}
}
