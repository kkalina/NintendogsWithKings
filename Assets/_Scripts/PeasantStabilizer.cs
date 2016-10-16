using UnityEngine;
using System.Collections;

public class PeasantStabilizer : MonoBehaviour {

    public Rigidbody core;
    public float stabilizerForce = 10f;
    public Transform target;
	/*public float xMax;
	public float zMax;
	public float xMin;
	public float zMin;
	 
	private float x;
	private float z;
	private float y;
	private Vector3 destination;
	private float cooldown;
	private NavMeshAgent agent;*/

    bool isStable = true;

	// Use this for initialization
	void Start () {
		// Add upward force to keep ragdoll upright
        //core.AddForce(Vector3.up * stabilizerForce);
		//agent = GetComponent<NavMeshAgent>();
        //cooldown = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {

        // Add upward force to keep ragdoll upright
        if (core.velocity.sqrMagnitude < 23f)
        {
            if (isStable)
            {
                core.AddForce(Vector3.up * stabilizerForce + -core.transform.forward * 30f);
                //core.transform.LookAt(target);
            }

            //Debug.Log(core.velocity.sqrMagnitude);
        }
        
        

        

        // countdown to change direction
        //cooldown -= Time.deltaTime;

        // Change direction if haven't changed direction in a while
        /*if (cooldown < 0) {
			destination.x = Random.Range(xMin, xMax);
			destination.z = Random.Range(zMin, zMax);
		    agent.SetDestination(destination);
		    cooldown = Random.Range(5,20);
		}*/
    }

    IEnumerator GetLimp() {
        isStable = false;
        yield return new WaitForSeconds(3f);
        isStable = true;
    }
}
