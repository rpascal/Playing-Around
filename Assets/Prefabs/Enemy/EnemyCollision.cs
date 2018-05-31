using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    [SerializeField] float speed = 10f;
    Rigidbody rigidBody;


    void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update() {
        Move();
    }


    private void Move() {
        var movement = Vector3.forward * speed * Time.deltaTime;
        rigidBody.MovePosition(transform.position + movement);
    }

    private void OnParticleCollision(GameObject other) {
        Destroy(gameObject);
    }

}
