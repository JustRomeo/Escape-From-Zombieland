using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Chase : MonoBehaviour {
    public Transform target;
    private NavMeshAgent agent;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = 1;
        agent.SetDestination(target.position);
    }
    void Update() {
        // agent.SetDestination(target.position);
    }
}
