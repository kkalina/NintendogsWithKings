using UnityEngine;
using System.Collections;

public class PeasantStabilizer : MonoBehaviour {

    public Rigidbody core;
    public float stabilizerForce = 10f;
	public float xMax;
	public float zMax;
	public float xMin;
	public float zMin;
	public float maxSpeed;
	 
	private float x;
	private float z;
	private float cooldown;
	private float rotation;

	// Use this for initialization
	void Start () {
        x = Random.Range(-maxSpeed, maxSpeed);
		z = Random.Range(-maxSpeed, maxSpeed);
		rotation = Mathf.Atan2(x, z) * (180 / 3.141592f);
		transform.localRotation = Quaternion.Euler( 0, rotation, 0);
		cooldown = Random.Range(5,20); 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Add upward force to keep ragdoll upright
        core.AddForce(Vector3.up * stabilizerForce);


        // countdown to change direction
		cooldown -= Time.deltaTime;


		// Conditionals to check if peasant is out of range
		if (transform.localPosition.x > xMax) {
			x = Random.Range(-maxSpeed, 0.0f);
			rotation = Mathf.Atan2(x, z) * (180 / 3.141592f);
			transform.localRotation = Quaternion.Euler(0, rotation, 0);
			cooldown = Random.Range(5,20); 
		}
		if (transform.localPosition.x < xMin) {
			x = Random.Range(0.0f, maxSpeed);
			rotation = Mathf.Atan2(x, z) * (180 / 3.141592f);
			transform.localRotation = Quaternion.Euler(0, rotation, 0); 
			cooldown = Random.Range(5,20); 
		}
		if (transform.localPosition.z > zMax) {
			z = Random.Range(-maxSpeed, 0.0f);
			rotation = Mathf.Atan2(x, z) * (180 / 3.141592f);
			transform.localRotation = Quaternion.Euler(0, rotation, 0); 
			cooldown = Random.Range(5,20); 
		}
		if (transform.localPosition.z < zMin) {
			z = Random.Range(0.0f, maxSpeed);
			rotation = Mathf.Atan2(x, z) * (180 / 3.141592f);
			transform.localRotation = Quaternion.Euler(0, rotation, 0);
			cooldown = Random.Range(5,20); 
		}

		// Change direction if haven't changed direction in a while
		if (cooldown < 0) {
			x = Random.Range(-maxSpeed, maxSpeed);
			z = Random.Range(-maxSpeed, maxSpeed);
			rotation = Mathf.Atan2(x, z) * (180 / 3.141592f);
			transform.localRotation = Quaternion.Euler(0, rotation, 0);
			cooldown = Random.Range(5,20); 
		}


		// Move ragdoll
		transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z + z);

	}

}
