using UnityEngine;
using System.Collections;

public class Assassin : MonoBehaviour {

    public float offset = 15;
    public GameObject king;
    public GameObject player;

    private Vector3 goal;
    private NavMeshAgent agent;

    private bool attack_player = false;


    public float x_k;
    public float z_k;


    public float directionChangeInterval = 1f;
    private float timeOfLastDirectionChange = 0f;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        float rand = Random.Range(1, 84);
        if(rand % 42 == 0) {
            attack_player = true;
        }
        king = GameObject.Find("King");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        x_k = king.transform.position.x;
        z_k = king.transform.position.z;
        /*
        float x_p = player.transform.position.x;
        float z_p = player.transform.position.z;
        
        if (!attack_player) {
            goal = new Vector3(Random.Range(x_k - offset, x_k + offset), king.transform.position.y, Random.Range(z_k - offset, z_k + offset));
        }
        else {
            goal = new Vector3(Random.Range(x_p - offset, x_p + offset), king.transform.position.y, Random.Range(z_p - offset, z_p + offset));
        }*/
        if (Time.time > (timeOfLastDirectionChange + directionChangeInterval))
        {
            goal = new Vector3(Random.Range(x_k - offset, x_k + offset), king.transform.position.y, Random.Range(z_k - offset, z_k + offset));
            agent.SetDestination(goal);
            timeOfLastDirectionChange = Time.time;
        }

    }
}
