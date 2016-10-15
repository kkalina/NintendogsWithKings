using UnityEngine;
using System.Collections;

public class Landmine : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll) {
		explosion.SetActive(true);
		GetComponent<Renderer>().enabled = false;
		Invoke("DestroyLandmine", 2);
	}

	void DestroyLandmine() {
		Destroy(gameObject);
	}
}
