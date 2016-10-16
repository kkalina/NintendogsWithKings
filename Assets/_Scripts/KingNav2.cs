using UnityEngine;
using System.Collections;

public class KingNav2 : MonoBehaviour {
    public Transform king;
    public Transform player;
    private KingNav kingNav;
    public float wait_time = .5f;
    public float follow_time = 4f;
    public float max_walk_distance = 50f;
    public bool reached_goal = true;
    private NavMeshAgent agent;
    private Vector3 goal;
    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        kingNav = GetComponent<KingNav>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.E)) {
            agent.SetDestination(player.position);
            goal = player.position;
            reached_goal = false;
            kingNav.enabled = false;
        }

        if (!reached_goal) {
            if (king.position == goal) {
                reached_goal = true;
            }
        }
        else {
            kingNav.enabled = true;
        }
    }
}
