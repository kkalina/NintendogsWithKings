using UnityEngine;
using System.Collections;

public class KingNav : MonoBehaviour {
    public Transform player;
    public float wait_time = 5000000f;
    public float max_walk_distance = 50f;
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
    public IEnumerator changeDirection() {
        Vector3 direction = Random.insideUnitSphere * max_walk_distance;
        direction += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(direction, out hit, Random.Range(0f, max_walk_distance), 1);

        Vector3 destination = hit.position;
        agent.SetDestination(destination);

        yield return new WaitForSeconds(wait_time);
    }

    public IEnumerator whistle() {
        agent.SetDestination(player.position);
        yield return new WaitForSeconds(wait_time);
    }


	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E)) {
           // StartCoroutine(whistle() );
        }

        StartCoroutine(changeDirection());
        
	}
}
