using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public float force = 100f;
    public float rad = 3f;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 10);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
        //rb.AddExplosionForce(force, transform.position + new Vector3 (10, 0, 0 ), rad);
	}
	
}
