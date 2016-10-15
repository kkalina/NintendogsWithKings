using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float force = 100f;
    //public float rad = 3f;
    public int lifetime = 4;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, lifetime);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
        //rb.AddExplosionForce(force, transform.position + new Vector3 (10, 0, 0 ), rad);
	}

    void OnCollisionEnter(Collision other) {
        //other.GetComponent<Rigidbody>().AddExplosionForce(50f, transform.position, 10f);
        if(other.rigidbody != null)
        {
            //other.rigidbody.AddRelativeForce(new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), 
            //    Random.Range(-100f, 100f)), ForceMode.Impulse);

        }
    }
	
}
