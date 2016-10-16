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
	private float y;
	private Vector3 destination;
	private float cooldown;
	private float rotation;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        destination.x = Random.Range(xMin, xMax);
		destination.z = Random.Range(zMin, zMax);

		agent = GetComponent<NavMeshAgent>();
	    agent.SetDestination(destination);
		cooldown = Random.Range(5,20); 
	}

	// Update is called once per frame
	void FixedUpdate () {
		// Add upward force to keep ragdoll upright
        core.AddForce(Vector3.up * stabilizerForce);

        // countdown to change direction
		cooldown -= Time.deltaTime;

		// Change direction if haven't changed direction in a while
		if (cooldown < 0) {
			x = Random.Range(xMin, xMax);
			z = Random.Range(zMin, zMax);
			destination.x = x;
			destination.z = z;
		    agent.SetDestination(destination);
		    cooldown = Random.Range(5,20);
		}
	}
}
