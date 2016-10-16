using UnityEngine;
using System.Collections;

public class peasantController : MonoBehaviour {

    public bool Assassin = false;

    private Vector3 goal;
    private NavMeshAgent navi;
    public float max_walk_distance = 50f;
    public float directionChangeInterval = 5f;
    private float timeOfLastDirectionChange = 0f;

    void Start ()
    {
        navi = GetComponent<NavMeshAgent>();
        if (Assassin)
        {

        }
        else
        {
            //pick random destination
            Vector3 direction = Random.insideUnitSphere * max_walk_distance;
            direction += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(direction, out hit, Random.Range(1f, max_walk_distance), 1);
            timeOfLastDirectionChange = Time.time;
            goal = hit.position;
            navi.SetDestination(goal);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (Assassin) {

        }
        else
        {
            if ((transform.position.x == goal.x && transform.position.z == goal.z) || (Time.time > (timeOfLastDirectionChange + directionChangeInterval)))
            {
                //pick new random destination
                Vector3 direction = Random.insideUnitSphere * max_walk_distance;
                direction += transform.position;
                NavMeshHit hit;
                NavMesh.SamplePosition(direction, out hit, Random.Range(1f, max_walk_distance), 1);
                timeOfLastDirectionChange = Time.time;
                goal = hit.position;
                navi.SetDestination(goal);
            }
        }
    }
}
