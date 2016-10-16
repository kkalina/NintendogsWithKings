﻿using UnityEngine;
using System.Collections;

public class KingNav : MonoBehaviour {
    public Transform king;
    public Transform player;
    public float wait_time = .5f;
    public float follow_time = 4f;
    public float max_walk_distance = 50f;
    public bool reached_goal = true;
    private NavMeshAgent agent;
    public Vector3 goal;

    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
      //  StartCoroutine(changeDirection());
    }

    //Lets you whistle
    void OnTriggerStay(Collider other) {
        if(other.tag == "Player") {
            if (Input.GetKeyDown(KeyCode.E)) {
                agent.SetDestination(player.position);
                goal = player.position;
                reached_goal = false;
            }
        }
    }

    void Update() {
        if (!reached_goal) {
            //Debug.Log(king.position);
            //Debug.Log(goal);
            if (king.position.x == goal.x && king.position.z == goal.z) {
                reached_goal = true;
            }
        }
        else {
            //random movement
            Vector3 direction = Random.insideUnitSphere * max_walk_distance;
            direction += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(direction, out hit, Random.Range(1f, max_walk_distance), 1);

            Vector3 destination = hit.position;
            agent.SetDestination(destination);
        }
    }
}