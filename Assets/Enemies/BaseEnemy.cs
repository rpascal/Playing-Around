using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class BaseEnemy : MonoBehaviour {

    public float Speed = 20f;
    public float Acceleration = 8f;

    protected Transform goal;
    protected NavMeshAgent agent;



    public BaseEnemy() {

    }

    protected virtual void Awake() {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = Speed;
        agent.acceleration = Acceleration;
    }

    protected virtual void Start() {
    }

    protected virtual void Update() {
        agent.destination = goal.position;
    }


    private void OnParticleCollision(GameObject other) {
        Destroy(gameObject);
    }

}
